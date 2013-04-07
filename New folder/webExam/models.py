from django.contrib.auth.models import User
from django.db import models

CHOICES = (
    ('A', 'Answer A'),
    ('B', 'Answer B'),
    ('C', 'Answer C'),
    ('D', 'Answer D'),
)


class Exam(models.Model):
    name = models.CharField(max_length=200)
    deadline = models.DateTimeField()
    def __unicode__( self ) :
        return self.name

class Question(models.Model):
    exam = models.ForeignKey(Exam)
    question = models.CharField(max_length=200)
    a = models.CharField(max_length=200)
    b = models.CharField(max_length=200)
    c = models.CharField(max_length=200)
    d = models.CharField(max_length=200)
    correctAnswer = models.CharField(max_length=1, choices=CHOICES)
    def __unicode__( self ) :
        return self.question


class Answer(models.Model):
    user = models.ForeignKey(User)
    question = models.ForeignKey(Question)
    answer = models.CharField(max_length=1, choices=CHOICES)
    def __unicode__( self ) :
        return self.answer
    class Meta:
        unique_together = ("user", "question")
