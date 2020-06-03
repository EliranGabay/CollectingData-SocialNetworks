import urllib.request
import os
from googlesearch import search
import urllib.request
import shutil
import sys
from twitter_scraper import Profile
from find_profile_image_Fid import convert_url_to_text_file_twitter,find_idF_in_text_twitter

# ----------------Global------------------
file_path = os.path.dirname(__file__)
# ----------------------------------------

if os.path.isdir(file_path+'/imagesTwitter'):
    shutil.rmtree(file_path+'/imagesTwitter')
if os.path.isdir(file_path+'/pagesTwitter'):
    shutil.rmtree(file_path+'/pagesTwitter')
words=['status','followers']

def get_users_in_lists(list_urls):
     f = open(file_path+"/inputTwitter.txt", "a")
     for tw_list in list_urls: 
        if not os.path.isdir(file_path+'/imagesTwitter'):
            os.mkdir(file_path+'/imagesTwitter')
        flag=0
        check=0
        for word in words:
            if word in tw_list.split("/"):
                flag = 1
        if(flag == 0):
            userName= tw_list.split('twitter.com/')[1]
            try :
                profile = Profile(userName)
                if NameRecev in profile.name :
                    for file in os.listdir(file_path+'/imagesTwitter'):
                        if profile.username in file:
                            check=1
                        if check==0:    
                            url_image=profile.profile_photo
                            urllib.request.urlretrieve(url_image, file_path+"/imagesTwitter/"+profile.username+'.jpg')
            except:
                pass
     f.close()

def GoogleSerch(Name):
    nameA=Name+" Twitter"
    LURL=[]
    for url in search(nameA , stop=100):
        LURL.append(url)
    return LURL

#-------------------Main--------------------------------------
NameRecev=' '.join(sys.argv[1:]) #get name from argv(user)
print("Run New Search....\n"+"Searching( "+NameRecev+" )....")
print("----------------------------------------------------------")
print("Searching in Google Search......")
UrlGoogle=GoogleSerch(NameRecev)

list_urls = []
for i in UrlGoogle:
    if "twitter.com" in i: 
        list_urls.append(i)
print("Searching in Twitter Search......")
convert_url_to_text_file_twitter(str(NameRecev).split(" ")[0],str(NameRecev).split(" ")[1])
find_idF_in_text_twitter()
get_users_in_lists(list_urls)

#------------------------------------------------------------


