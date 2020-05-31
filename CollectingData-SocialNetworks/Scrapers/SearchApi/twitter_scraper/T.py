from twitter_scraper import Profile
import urllib.request
import os

# ----------------Global------------------
file_path = os.path.dirname(__file__)
# ----------------------------------------

profile = Profile("elirangabay1")
#profile.to_dict()
url_image=profile.profile_photo


urllib.request.urlretrieve(url_image, file_path+"/imagesP/"+profile.username+'.jpg')
