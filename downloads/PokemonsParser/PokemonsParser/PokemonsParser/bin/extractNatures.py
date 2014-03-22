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
	natures = [()]
	natures.pop(0)
	while not endCondition('="background: #ddf">\n<th> ', 'id="Nature_table">Nature table</span></h3', source):
		(name, source) = extractInfo('="background: #ddf">\n<th> ', '\n</th>', source)
		(junk, source) = extractInfo('</td>', 'style=', source)
		if not endCondition('"> ', 'background: #ddf"', source):
			(increased, source) = extractInfo('"> ', '\n</td>', source)
			(decreased, source) = extractInfo('"> ', '\n</td>', source)
			natures.append((name, increased, decreased))
		else:
			natures.append((name, 'None', 'None'))
			
	pokeFile = open('I:/Visual_Studio_Projects/PokemonsParser/PokemonsParser/bin/Debug/natures2.xml', 'a')

	for t in natures:
		pokeFile.write('<Nature>\n')
		pokeFile.write('<Name>' + str(t[0]) + '</Name>\n')
		if str(t[1]) == 'None':
			pokeFile.write('<Effect>None</Effect>\n</Nature>\n')
		else:
			pokeFile.write('<Effect>Increased ' + str(t[1]) + ', Decreased ' + str(t[2]) + '</Effect>\n</Nature>\n')

	pokeFile.close()