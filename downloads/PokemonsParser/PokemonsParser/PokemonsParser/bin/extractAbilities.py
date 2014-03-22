import urllib2

def readPage(pagestring):
	try:
		page = urllib2.urlopen(pagestring)
		html = page.read()
		page.close()
		fail = 0
	except urllib2.URLError:
		print 'There was a read error...'
		fail = 1
        
	pullInformation(html)
        
def extractInfo(startMatch, endMatch, source):
    start = source.find(startMatch) + len(startMatch)
    end = source.find(endMatch, start)
    returnVal = source[start:end]
    source = source[end:len(source)]
    return (returnVal, source)

def endCondition(currentItem, endItem, source):
    cLoc = source.find(currentItem)
    eLoc = source.find(endItem)
    if cLoc > eLoc or cLoc == -1:
        return 1
    else:
        return 0
		
def pullInformation(source):
	# Looking for each name.
	abilities = [()]
	abilities.pop(0)
	while not endCondition('(Ability)">', 'id="In_Pok.C3.A9mon_Conquest"', source):
		(name, source) = extractInfo('(Ability)">', '</a>', source)
		(effect, source) = extractInfo('style="text-align:left;"> ', '\n</td>', source)
		abilities.append((name, effect))
	
	pokeFile = open('I:/Visual_Studio_Projects/PokemonsParser/PokemonsParser/bin/Debug/abilities.xml', 'a')

	for t in abilities:
		pokeFile.write('<Ability>\n')
		pokeFile.write('<Name>' + str(t[0]) + '</Name>\n')
		pokeFile.write('<Effect>' + str(t[1]) + '</Effect>\n</Ability>\n')

	pokeFile.close()