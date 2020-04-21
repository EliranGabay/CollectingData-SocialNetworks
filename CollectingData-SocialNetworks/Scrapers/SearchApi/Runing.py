import urllib.request
import os
from googlesearch import search
import facebook_snooper
from facebook_snooper.dump import dump_search, dump_info
import urllib.request
from find_profile_image_Fid import convert_url_to_text_file
from find_profile_image_Fid import find_idF_in_text
import shutil
import sys

# ----------------Global------------------
file_path = os.path.dirname(__file__)
# ----------------------------------------
if os.path.isdir(file_path+'/pages'):
    shutil.rmtree(file_path+'/pages')
if os.path.isdir(file_path+'/imagesP'):
    shutil.rmtree(file_path+'/imagesP')


def GoogleSerch(Name):
    nameA="Name"+"facebook"
    LURL=[]
    for url in search(nameA , stop=20):
        LURL.append(url)
    return LURL

def FacebookSerch(Name):
    fb = facebook_snooper.init_session()
    fb.log_in('daxip24881@hubopss.com', '19eliran19')
    results = fb.search(Name)
    ID=dump_search(results, pretty=True)
    return ID

NameRecev=' '.join(sys.argv[1:]) #get name from argv(user)
UrlGoogle=GoogleSerch(NameRecev)
UrlFacebook = FacebookSerch(NameRecev)
UrlGoogle.extend(UrlFacebook)
words = ['public', 'notes', 'louder', 'groups', 'posts','pages','people','help']

open(file_path+'/input.txt','w+')

for i in UrlGoogle:
    if "facebook.com" in i:
        flag = 0
        name = i.split('facebook.com/')
        name = name[1]
        for word in words:
            if word in name.split("/"):
                flag = 1
            if len(i) > 65:
                flag = 1
        if(flag == 0):
            with open(file_path+'/input.txt') as f:
                if not name in f.read():
                    f = open(file_path+"/input.txt", "a")
                    if 'profile.php?' in name:
                        urlSplit=name.split("&")
                        f.write('https://www.facebook.com/'+urlSplit[0]+'\n')
                    else:
                        urlSplit=name.split("?")
                        f.write('https://www.facebook.com/'+urlSplit[0]+'\n')
                    f.close()

convert_url_to_text_file()
find_idF_in_text()



