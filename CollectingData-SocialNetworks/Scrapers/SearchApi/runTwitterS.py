import urllib.request
import os
from googlesearch import search
import urllib.request
from find_profile_image_Fid import convert_url_to_text_file
from find_profile_image_Fid import find_idF_in_text
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
def GoogleSerch(Name):
    nameA="Name"+"Twitter"
    LURL=[]
    for url in search(nameA , stop=20):
        LURL.append(url)
    return LURL
NameRecev=' '.join(sys.argv[1:]) #get name from argv(user)
UrlGoogle=GoogleSerch(NameRecev)
open(file_path+'/inputTwitter.txt','w+')

for i in UrlGoogle :
    if "twitter.com" in i :
        f = open(file_path+"/inputTwitter.txt", "a")