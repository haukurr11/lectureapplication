from django.conf.urls import patterns, url
from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
                       url(r'^$', 'webExam.views.index'),
                       (r'(\d+)', 'webExam.views.webexam'),
)