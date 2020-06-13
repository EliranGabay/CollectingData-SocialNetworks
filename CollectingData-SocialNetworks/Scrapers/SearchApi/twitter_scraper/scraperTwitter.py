import os
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
if not os.path.isdir(file_path+'/tweet'):
    os.mkdir(file_path+'/tweet')
#scrap data from user twitter
profile = Profile(userName)

print("scraper data from Twitter:")
print("user name: {}".format(userName))
print("---------------------------------------------------")
#write to file
f = open(file_path+'/'+userName+'.txt', "w",encoding="utf-8")
f.write("USERNAME:\n{}\n".format(profile.username))
f.write("NAME:\n{}\n".format(profile.name))
f.write("BIRTHDAY:\n{}\n".format(profile.birthday))
f.write("LOCATION:\n{}\n".format(profile.location))
f.write("BIOGRAPHY:\n{}\n".format(profile.biography))
f.write("Tweets Amount:\n{}\n".format(profile.tweets_count))
f.write("Followers Amount:\n{}\n".format(profile.followers_count))
f.write("Following Amount:\n{}\n".format(profile.following_count))
f.close()
print("scraper successfully done....")