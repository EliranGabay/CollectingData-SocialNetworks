# -*- coding: utf-8 -*-
from scrapy.exceptions import DropItem
from scrapy.utils.project import get_project_settings
import logging
import pymongo
import json
import os


from TweetScraper.items import Tweet, User
from TweetScraper.utils import mkdirs

SETTINGS = get_project_settings()

logger = logging.getLogger(__name__)


class SaveToFilePipeline(object):
    ''' pipeline that save data to disk '''

    def __init__(self):
        print("pirst")
        self.saveTweetPath = SETTINGS['SAVE_TWEET_PATH']
        #self.saveUserPath = SETTINGS['SAVE_USER_PATH']
        mkdirs(self.saveTweetPath)  # ensure the path exists
        # mkdirs(self.saveUserPath)

    def process_item(self, item, spider):
        if isinstance(item, Tweet):
            savePath = os.path.join(self.saveTweetPath, item['usernameTweet'])
            savePath+=".txt"
            if os.path.isfile(savePath):
                with open(savePath, 'a', encoding='utf-8') as f:
                    f.write("\n")
                    json.dump(dict(item), f, ensure_ascii=False)
            else:
                self.save_to_file(item, savePath)
                logger.debug("Add tweet:%s" % item['url'])

        # elif isinstance(item, User):
        #    savePath = os.path.join(self.saveUserPath, item['ID'])
        #    if os.path.isfile(savePath):
        #        pass
        #    else:
        #        self.save_to_file(item, savePath)
        #        logger.debug("Add user:%s" % item['screen_name'])

        else:
            logger.info("Item type is not recognized! type = %s" % type(item))

    def save_to_file(self, item, fname):
        with open(fname, 'w', encoding='utf-8') as f:
            json.dump(dict(item), f, ensure_ascii=False)
