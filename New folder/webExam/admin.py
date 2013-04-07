from django.contrib import admin
from webExam.models import *


class QuestionInline(admin.StackedInline):
    model = Question
    extra = 0


class ExamAdmin(admin.ModelAdmin):
    inlines = [QuestionInline]
    list_display = ['name', 'deadline']

admin.site.register(Exam,ExamAdmin)