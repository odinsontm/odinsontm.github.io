from django.db import models
from django.contrib.auth.models import User
from datetime import date, datetime

class Post(models.Model):
    title = models.CharField(max_length=255)
    header_image = models.ImageField(null=True, blank=True, upload_to="exclusiveImages/")
    video = models.FileField(null=True, blank = True, upload_to="exclusiveVids/")
    caption = models.CharField(max_length=511)
    body = models.TextField()
    post_date = models.DateField(auto_now_add=True)

    def __str__(self):
        return self.title


class Calender(models.Model):
    title = models.CharField(max_length=255)
    calenderLink = models.CharField(max_length=511)

    def __str__(self):
        return self.title


class Newsletter(models.Model):
    title = models.CharField(max_length=255)
    header_image = models.ImageField(null=True, blank=True, upload_to="NewsImages/")
    body = models.TextField()
    post_date = models.DateField(default=datetime.now)
    link = models.CharField(max_length=511, null= True, blank=True)

    def __str__(self):
        return self.title


class MembershipInfo(models.Model):
    cardholderOne = models.CharField(max_length=255)
    cardholderTwo = models.CharField(max_length=255)
    LookupID = models.CharField(max_length=255)
    Type = models.CharField(max_length=255)
    MemberID = models.CharField(max_length=255)
    MemberSince = models.CharField(max_length=255)
    ValidThrough = models.CharField(max_length=255)


# Leave this at bottom of models.py
def create_superuser_if_necessary():
    # Set the name and initial password you want the superuser to have here.
    # AFTER THIS SUPERUSER IS CREATED ON HEROKU, YOU ***MUST*** IMMEDIATELY CHANGE ITS PASSWORD
    # THROUGH THE ADMIN INTERFACE. (This password is stored in cleartext in a GitHub repository,
    # so it is not acceptable to use it when there is actual client data!)
    SUPERUSER_NAME = 'admin'
    SUPERUSER_PASSWORD = 'leo'


    if not User.objects.filter(username=SUPERUSER_NAME).exists():
        superuser = User(
            username=SUPERUSER_NAME,
            is_superuser=True,
            is_staff=True
        )

        superuser.save()
        superuser.set_password(SUPERUSER_PASSWORD)
        superuser.save()


# Once the superuser has been created on Heroku, you can comment out this line if you wish
create_superuser_if_necessary()