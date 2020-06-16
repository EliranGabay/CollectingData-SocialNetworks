#!/bin/sh
pip install scrapy
pip install configparser
scrapy crawl TweetScraper -a query=$1