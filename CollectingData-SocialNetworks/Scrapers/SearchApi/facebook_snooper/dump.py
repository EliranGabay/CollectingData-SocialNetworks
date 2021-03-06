from .core._parser import InfoTypes, ResultTypes
from pathlib import Path
import urllib.request


def dump_search(data, pretty=False):
    returnList=[]
    for type_, id_, texts, link in data:
        type_ = ResultTypes.tostring(type_) if pretty else type_
        link_ = _shorten(link, 50) if pretty else link
        #print(f'{type_} {id_} {link_}')
        #for text in texts:
            #print(f' {_shorten(text, 70)}')
        returnList.append(f'{link_}')
    #print (returnList)
    return (returnList)




def dump_info(data, pretty=False):
    name = data
    print(f'{name}\n')
    

def _shorten(text, max_len):
    if len(text) > max_len:
        return f'{text[:60]}...'
    else:
        return text