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
	types = [()]
	types.pop(0)
	(junk, source) = extractInfo('<h2><span class="mw-headline" id="Generations_II-V">Generations II-V', '</span>', source)
	(junk, source) = extractInfo('<th rowspan="17" style="background:#A44C4B"> <small>A<br />t<br />t<br />', 'a<br /', source)
	while not endCondition('(type)" title="', '<td colspan="19" style="border-bottom-left-radius: 5', source):
		(name, source) = extractInfo('(type)" title="', '"><img alt="', source)
		# There are 17 types to get information on...
		
		(type1, source) = extractInfo('> ', '\n', source)
		# print type1
		(type2, source) = extractInfo('> ', '\n', source)
		(type3, source) = extractInfo('> ', '\n', source)
		(type4, source) = extractInfo('> ', '\n', source)
		(type5, source) = extractInfo('> ', '\n', source)
		(type6, source) = extractInfo('> ', '\n', source)
		(type7, source) = extractInfo('> ', '\n', source)
		(type8, source) = extractInfo('> ', '\n', source)
		(type9, source) = extractInfo('> ', '\n', source)
		(type10, source) = extractInfo('> ', '\n', source)
		(type11, source) = extractInfo('> ', '\n', source)
		(type12, source) = extractInfo('> ', '\n', source)
		(type13, source) = extractInfo('> ', '\n', source)
		(type14, source) = extractInfo('> ', '\n', source)
		(type15, source) = extractInfo('> ', '\n', source)
		(type16, source) = extractInfo('> ', '\n', source)
		(type17, source) = extractInfo('> ', '\n', source)
		
		types.append((name, type1, type2, type3, type4, type5, type6, type7, type8, type9, type10, type11, type12, type13, type14, type15, type16, type17))
			
	pokeFile = open('C:/Users/Jordan/Documents/Visual Studio 2012/Projects/PokemonsParser/PokemonsParser/bin/Debug/types.xml', 'a')

	for t in types:
		pokeFile.write('<Type TypeName = \'' + str(t[0]) + '\'>\n')
		pokeFile.write('<TypeAttack>Normal</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[1]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Fighting</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[2]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Flying</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[3]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Poison</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[4]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Ground</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[5]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Rock</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[6]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Bug</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[7]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Ghost</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[8]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Steel</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[9]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Fire</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[10]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Water</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[11]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Grass</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[12]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Electric</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[13]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Psychic</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[14]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Ice</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[15]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Dragon</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[16]) + '</Effect>\n')
		pokeFile.write('<TypeAttack>Dark</TypeAttack>\n')
		pokeFile.write('<Effect>' + str(t[17]) + '</Effect>\n')
		pokeFile.write('</Type>\n')

	pokeFile.close()