import urllib.request
import os
# serach rid= to get id from facebook

# ----------------Global------------------
file_path = os.path.dirname(__file__)
# ----------------------------------------


def convert_url_to_text_file():
    if not os.path.isdir(file_path+'/pages'):
        os.mkdir(file_path+'/pages')
    with open(file_path+'/input.txt') as fp:
        for url in fp.readlines():
            url_path = url.split('\n')[0]
            if "profile.php?" in url_path:
                file_name = url_path.split('id=')[1]+'@'
            elif "www.facebook.com" in url_path:
                file_name = url_path.split('facebook.com/')[1]+'$'
            else:
                file_name = url_path.split('facebook.com/')[1]
            try:
                urllib.request.urlretrieve((url_path), file_path+"/pages/"+file_name+".txt")
            except:
                pass
    fp.close()


def get_image_from_idF(idf):
    if not os.path.isdir(file_path+'/imagesP'):
        os.mkdir(file_path+'/imagesP')
    url_image = "http://graph.facebook.com/"+str(idf)+"/picture?type=large"
    try:
        urllib.request.urlretrieve(url_image, file_path+"/imagesP/"+idf+'.jpg')
    except:
        pass


def find_idF_in_text():
    for file in os.listdir(file_path+'/pages'):
        with open(file_path+"/pages/"+file, encoding="utf8") as fp:
            for line in fp.readlines():
                idF = ""
                if '@' in file:  # type url is https://www.facebook.com/profile.php?id=
                    idF = file.split('@.txt')[0]
                    get_image_from_idF(idF)
                elif '$' in file:  # type url is www.facebook.com
                    result = line.find('id="pagelet_timeline_app_collection_')
                    if not result == -1:
                        i = result+36
                        while not(line[i] == ':'):
                            idF += str(line[i])
                            i += 1
                        get_image_from_idF(idF)
                else:  # type url is m.facebook.com
                    result = line.find(';rid=')
                    if not result == -1:
                        i = result+5
                        while not(line[i] == '&'):
                            idF += str(line[i])
                            i += 1
                        get_image_from_idF(idF)


# id="pagelet_timeline_app_collection_ ------: #to find id in www
# -----------Run-----------------
#convert_url_to_text_file()
#find_idF_in_text()
