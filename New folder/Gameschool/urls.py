from django.conf.urls import patterns, include, url
from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
                       url(r'^admin/logout/$', 'django.contrib.auth.views.logout', {'next_page': '/'}),
                       (r'^admin/', include(admin.site.urls)),
                       (r'^$', 'django.views.generic.simple.redirect_to', {'url': '/webExam'}),
                       (r'^webExam/', include('webExam.urls', namespace="webExam"),),
                       (r'^accounts/logout/$', 'django.contrib.auth.views.logout', {'next_page': '/'}),
                       (r'^accounts/',  include('django.contrib.auth.urls')),
)