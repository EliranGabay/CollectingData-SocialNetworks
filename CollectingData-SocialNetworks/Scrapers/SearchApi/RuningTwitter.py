import urllib.request
import os
from googlesearch import search
import urllib.request
import shutil
import sys

# ----------------Global------------------
file_path = os.path.dirname(__file__)
# ----------------------------------------
if os.path.isdir(file_path+'/pagesTwitter'):
    shutil.rmtree(file_path+'/pagesTwitter')
if os.path.isdir(file_path+'/imagesTwitter'):
    shutil.rmtree(file_path+'/imagesTwitter')
print("Run New Search.......")

def get_users_in_lists(list_urls):
     users_list = []   
     for tw_list in list_urls: 
        user = tw_list.split('/')[1]
        list_name = tw_list.split('/')[3]
        list_members_output = api.list_members(user, list_name)
        f = open(file_path+"/inputTwitter.txt", "a")
        for user_id in list_members_output:
            f.write('twitter.com/'+user)




def GoogleSerch(Name):
    nameA=Name+" Twitter"
    LURL=[]
    for url in search(nameA , stop=100):
        LURL.append(url)
    return LURL


NameRecev=' '.join(sys.argv[1:]) #get name from argv(user)
UrlGoogle=GoogleSerch(NameRecev)

list_urls = []
for i in UrlGoogle:
    if "twitter.com" in i:
        print(i)
        list_urls.append(i)
input("1")
#get_users_in_lists(list_urls)
#print(list_urls)
