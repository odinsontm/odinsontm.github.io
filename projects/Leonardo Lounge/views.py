from django.contrib.auth.decorators import login_required
from django.contrib.auth.mixins import LoginRequiredMixin
from django.shortcuts import render
from django.views.generic import ListView, DetailView, View

from .models import Post, Calender, Newsletter, MembershipInfo


@login_required
def dashboard(request):
    context = {

    }
    return render(request, 'dashboard.html', context)


@login_required
def newsletter(request):
    context = {}
    return render(request, 'newsletter.html', context)


@login_required
def account(request):
    context = {}
    return render(request, 'account.html', context)


@login_required
def member(request):
    context = {}
    return render(request, 'membership.html', context)


class exclusiveView(LoginRequiredMixin, ListView):
    model = Post
    template_name = 'exclusive.html'
    ordering = ['-id']


class exclusiveDetailView(LoginRequiredMixin, DetailView):
    model = Post
    template_name = 'exclusive_detail.html'

class newsletterView(LoginRequiredMixin, ListView):
    model = Newsletter
    template_name = 'newsletter.html'


class calenderView(LoginRequiredMixin, ListView):
    model = Calender
    template_name = 'calendar.html'

class cardView(LoginRequiredMixin, ListView):
    model = MembershipInfo
    template_name = 'membership.html'
