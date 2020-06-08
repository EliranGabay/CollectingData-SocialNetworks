﻿import os
import sys
from twitter_scraper import Profile

userName=sys.argv[1]
file_path=sys.argv[2]

#create dir /data/username
if not os.path.isdir(file_path+'/data'):
            os.mkdir(file_path+'/data')
file_path+='/data'
if not os.path.isdir(file_path+'/'+userName):
    os.mkdir(file_path+'/'+userName)
file_path+='/'+userName

#scrap data from user twitter
profile = Profile(userName)

print("scraper data from Twitter:")
print("user name: {}".format(userName))
print("---------------------------------------------------")
#write to file
with open(file_path+'/'+userName+'.txt','w+') as f:
    f.write("USERNAME:\n{}\n".format(profile.username))
    f.write("NAME:\n{}\n".format(profile.name))
    f.write("BIRTHDAY:\n{}\n".format(profile.birthday))
    f.write("LOCATION:\n{}\n".format(profile.location))
    f.write("BIOGRAPHY:\n{}\n".format(profile.biography))
    f.write("TWEETSC:\n{}\n".format(profile.tweets_count))
    f.write("FOLLOWERSC:\n{}\n".format(profile.followers_count))
    f.write("FOLLOWINGC:\n{}\n".format(profile.following_count))
    f.close()
print("scraper successfully done....")