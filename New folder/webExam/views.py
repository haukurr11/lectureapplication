from webExam.models import *
from django.shortcuts import *
from django.contrib.auth.decorators import login_required
from datetime import datetime

@login_required
def index(request):
    if request.user.groups.filter(name='Teachers').exists():
        return HttpResponseRedirect("/admin/webExam/exam")
    exams = Exam.objects.all()
    answered = len(Answer.objects.filter(user_id=request.user))
    total = len(Question.objects.all())
    context = {'exams': exams, 'answered': answered, 'total': total}
    return render(request, 'webExam/index.html', context)


@login_required
def webexam(request, exam_id):
    query = "SELECT  a.* FROM webExam_answer a," \
            "webExam_question q,auth_user u " \
            "where a.question_id=q.id " + "and a.user_id=" \
            + str(request.user.id) + " and q.exam_id=" + str(exam_id)
    has_answered = Answer.objects.raw(query)
    exam = Exam.objects.get(pk=exam_id)
    if len(list(has_answered)) == 0 and exam.deadline > datetime.now():
        if request.method == 'POST':
            questions = Question.objects.filter(exam=exam_id)
            user = User.objects.get(pk=request.user.id)
            for question in questions:
                if str(question.id) in request.POST:
                    answer = Answer(user=user,
                                    question=question,
                                    answer=request.POST[str(question.id)])
                    answer.save()
            return HttpResponseRedirect("/webExam/exam" + exam_id)
        else:
            q = Question.objects.filter(exam_id=exam_id)
            model = {"exam": exam, "questions": q}
            return render(request, 'webExam/view_exam.html', model)
    else:
        questions = Question.objects.filter(exam=exam_id)
        highscore_list = toplist(exam_id)
        model = {"highscore": highscore_list, "questions": len(questions)}
        return render(request, 'webExam/highscore.html', model)


def toplist(exam_id):
    from django.db import connection
    cursor = connection.cursor()
    cursor.execute("SELECT u.username,COUNT(*) FROM webExam_answer a,"
                   "webExam_question q,auth_user u where a.user_id=u.id "
                   "and a.question_id=q.id and q.exam_id=" + exam_id +
                   " and UPPER(q.correctAnswer)=UPPER(a.answer) "
                   "group by a.user_id ORDER BY COUNT(*) DESC")
    rows = cursor.fetchall()
    return rows