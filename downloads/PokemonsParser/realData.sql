/*
1. use jdonais-pokemonproject

2. select table_name from information_schema.tables where table_schema = 'jdonais-pokemonproject';

3. drop table Abilities, Ability, Evolutions, MoveSet, Moves, Nature, Natures, Pokemon, TMs, Type_, Types, Strengths, Weaknesses;

4. \T logFile.txt;

5. \. name.sql

6. When running project delete all sql files except sql_0_dbCreation.sql
*/
-- abilities
INSERT INTO Abilities (GUID, Name, Effect) VALUES('d89ca940-5961-4c70-8d3b-cdc3ffc18250','Forewarn','Normal-type moves become Flying-type moves.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('1b1454fe-ddd7-4ee7-b345-111054d328ee','Adaptability','Powers up moves of the same type.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('5de94a53-78a5-4451-a144-d4c3de615e78','Aftermath','Damages the foe landing the finishing hit.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('bd8f4ca6-a7f6-463a-bb79-afc7ad05bd1d','Air Lock','Eliminates the effects of weather.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('d9d7e302-13ef-41d6-8e78-9879f766e0a4','Analytic','Strengthens moves when moving last.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('4356cd66-6f6e-4c8e-be0d-ad97692c8d8e','Anger Point','Raises Attack upon taking a critical hit.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('13859887-efe4-4239-b2c3-b2d9b29430bc','Anticipation','Senses the foe’s dangerous moves.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('2f869e94-bca2-487f-8edd-75ed5db45674','Arena Trap','Prevents the foe from fleeing.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('649fc8b5-a646-4387-8c8c-157dd60682bc','Aroma Veil','Protects allies from attacks that limit their move choices.');
INSERT INTO Abilities (GUID, Name, Effect) VALUES('d333147c-20a4-4a0e-92ef-5326f1477553','Aura Break','The effects of "Aura" Abilities are reversed.');
-- pokemon
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('3474b644-2bdd-4c9a-8b8e-d40ac47c53e6','Bulbasaur',001,'15.2lbs','2''04"',45,49,49,65,65,45,'A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('985ecb8e-0b9a-4a42-91a9-c2ca8b404dc8','Ivysaur',002,'28.7lbs','3''03″',60,62,63,80,80,60,'When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('2654060b-4052-4197-906f-9f5f29c2a3c1','Venusaur',003,'220.5lbs','6''07"',80,82,83,100,100,80,'The plant blooms when it is asorbing solar energy. It stays on the move to seek sunlight.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('22d794c8-a4c7-49d7-a2ce-756c6220f2e1','Charmander',004,'18.7lbs','2''00"',39,52,43,60,50,65,'Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('98315c60-5ea3-4460-a60a-6d6c86bb28f1','Charmeleon',005,'41.9lbs','3''07"',58,64,58,80,65,80,'When it swings its burning tail, it elevates the temperature to unbearably high levels.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('e4b57b20-4560-45de-82dc-9a8e09799c40','Charizard',006,'199.5lbs','5''07"',78,84,78,109,85,100,'It spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('a9514366-3311-4322-a709-8fed85847d52','Squirtle',007,'19.8lbs','1''08"',44,48,65,50,64,43,'After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('5f733105-3ff9-4b8b-8435-08658cc3ba29','Wartortle',008,'49.6lbs','3''03"',59,63,80,65,80,58,'Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('a6a6fbc7-3b6d-45ac-87f7-b8dc0ea8c681','Blastoise',009,'188.5lbs','5''03"',79,83,100,85,105,78,'A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles.');
INSERT INTO Pokemon(GUID,Name,NationalID,Height,Weight,HP,Attack,Defense,SpecialAtk,SpecialDef,Speed,Description) VALUES('8101cb53-c19c-474d-988f-884bf5cbdaf3','Caterpie',010,'6.4lbs','1''00"',45,30,35,20,20,45,'Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.');
-- strengths
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','b3027dc2-ab12-42b1-86df-c8d3761601f8');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','83f19441-f563-43c9-8e3b-73be447b052e');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','0b743f7c-3926-4a20-b6ce-98e4ef679f9f');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('c76261d5-9412-4a14-b1e7-d86d745fe5ca','0bd27b78-a64f-444f-ac74-3129d36c8c32');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('fc4c6451-36fd-41ff-a453-a153295d9e28','d413a3f8-5d39-4c19-9c9d-c996fe339fdb');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('fc4c6451-36fd-41ff-a453-a153295d9e28','aa13a0c7-ad05-40c7-9cc6-d6f65fb804e5');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('fc4c6451-36fd-41ff-a453-a153295d9e28','0bd27b78-a64f-444f-ac74-3129d36c8c32');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('fc4c6451-36fd-41ff-a453-a153295d9e28','e49d221d-5ac7-4c10-ba5c-957275c0a65a');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('4ab2383d-d2ef-49d1-bc9f-71120ccf0481','533345b6-8a99-42c9-8eb4-207be2698d41');
INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES ('4ab2383d-d2ef-49d1-bc9f-71120ccf0481','d413a3f8-5d39-4c19-9c9d-c996fe339fdb');
-- tm link
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','f94a848b-ff8d-4a03-8c2a-d397dd66418a');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','2f037cfc-c802-46fa-81c0-41c051db7c01');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','486c71b3-13f6-476a-b780-f522b2ca8d02');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','11e5042e-d1c2-4ed4-861b-8d62acfdb943');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','ea6279c1-5b63-4468-8a8e-1d995c39db7d');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','9c71aae4-210f-4a17-8ecb-1ae411aebb96');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','6a0c25a7-65a9-4add-b7ed-7045cbf982ee');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','da1e4fb6-24d7-4a84-9441-da45b0738e41');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','8e668f2d-2ec7-464e-a27e-370716177e5f');
INSERT INTO TMs(PokemonUID, MoveUID) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','e8d2b17f-d298-475e-8783-e1813bb9d2eb');
-- type link
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('3474b644-2bdd-4c9a-8b8e-d40ac47c53e6','0bd27b78-a64f-444f-ac74-3129d36c8c32');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('3474b644-2bdd-4c9a-8b8e-d40ac47c53e6','c76261d5-9412-4a14-b1e7-d86d745fe5ca');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('985ecb8e-0b9a-4a42-91a9-c2ca8b404dc8','0bd27b78-a64f-444f-ac74-3129d36c8c32');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('985ecb8e-0b9a-4a42-91a9-c2ca8b404dc8','c76261d5-9412-4a14-b1e7-d86d745fe5ca');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('2654060b-4052-4197-906f-9f5f29c2a3c1','0bd27b78-a64f-444f-ac74-3129d36c8c32');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('2654060b-4052-4197-906f-9f5f29c2a3c1','c76261d5-9412-4a14-b1e7-d86d745fe5ca');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('22d794c8-a4c7-49d7-a2ce-756c6220f2e1','fc4c6451-36fd-41ff-a453-a153295d9e28');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('98315c60-5ea3-4460-a60a-6d6c86bb28f1','fc4c6451-36fd-41ff-a453-a153295d9e28');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('e4b57b20-4560-45de-82dc-9a8e09799c40','fc4c6451-36fd-41ff-a453-a153295d9e28');
INSERT INTO Type_(PokemonUID, TypeUID) VALUES ('e4b57b20-4560-45de-82dc-9a8e09799c40','4ab2383d-d2ef-49d1-bc9f-71120ccf0481');
-- types
INSERT INTO Types(GUID, Name) VALUES('0bd27b78-a64f-444f-ac74-3129d36c8c32','Grass');
INSERT INTO Types(GUID, Name) VALUES('c76261d5-9412-4a14-b1e7-d86d745fe5ca','Poison');
INSERT INTO Types(GUID, Name) VALUES('fc4c6451-36fd-41ff-a453-a153295d9e28','Fire');
INSERT INTO Types(GUID, Name) VALUES('4ab2383d-d2ef-49d1-bc9f-71120ccf0481','Flying');
INSERT INTO Types(GUID, Name) VALUES('0b743f7c-3926-4a20-b6ce-98e4ef679f9f','Water');
INSERT INTO Types(GUID, Name) VALUES('d413a3f8-5d39-4c19-9c9d-c996fe339fdb','Bug');
INSERT INTO Types(GUID, Name) VALUES('bb815b8a-b1cf-4d86-bd55-5065844992e8','Normal');
INSERT INTO Types(GUID, Name) VALUES('7a478751-120f-4342-bd8b-cdeb908aa2d0','Electric');
INSERT INTO Types(GUID, Name) VALUES('b3027dc2-ab12-42b1-86df-c8d3761601f8','Ground');
INSERT INTO Types(GUID, Name) VALUES('533345b6-8a99-42c9-8eb4-207be2698d41','Fighting');
-- weakness
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','4ab2383d-d2ef-49d1-bc9f-71120ccf0481');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','c76261d5-9412-4a14-b1e7-d86d745fe5ca');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','d413a3f8-5d39-4c19-9c9d-c996fe339fdb');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','fc4c6451-36fd-41ff-a453-a153295d9e28');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('0bd27b78-a64f-444f-ac74-3129d36c8c32','e49d221d-5ac7-4c10-ba5c-957275c0a65a');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('c76261d5-9412-4a14-b1e7-d86d745fe5ca','b3027dc2-ab12-42b1-86df-c8d3761601f8');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('c76261d5-9412-4a14-b1e7-d86d745fe5ca','71e379e5-24c3-4d90-af35-ce4d341a0382');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('fc4c6451-36fd-41ff-a453-a153295d9e28','b3027dc2-ab12-42b1-86df-c8d3761601f8');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('fc4c6451-36fd-41ff-a453-a153295d9e28','83f19441-f563-43c9-8e3b-73be447b052e');
INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES ('fc4c6451-36fd-41ff-a453-a153295d9e28','0b743f7c-3926-4a20-b6ce-98e4ef679f9f');
-- ability link
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('3474b644-2bdd-4c9a-8b8e-d40ac47c53e6','935b1506-3183-4867-81d1-61e37097886c');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('3474b644-2bdd-4c9a-8b8e-d40ac47c53e6','3d0655cb-24ee-4ff6-bd13-9c79b055d834');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('985ecb8e-0b9a-4a42-91a9-c2ca8b404dc8','935b1506-3183-4867-81d1-61e37097886c');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('985ecb8e-0b9a-4a42-91a9-c2ca8b404dc8','3d0655cb-24ee-4ff6-bd13-9c79b055d834');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('2654060b-4052-4197-906f-9f5f29c2a3c1','935b1506-3183-4867-81d1-61e37097886c');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('2654060b-4052-4197-906f-9f5f29c2a3c1','3d0655cb-24ee-4ff6-bd13-9c79b055d834');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('22d794c8-a4c7-49d7-a2ce-756c6220f2e1','ae97e5ef-3c43-4498-9506-ae790d45ef84');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('22d794c8-a4c7-49d7-a2ce-756c6220f2e1','c2089431-d042-4695-869d-1c4f0d79cd78');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('98315c60-5ea3-4460-a60a-6d6c86bb28f1','ae97e5ef-3c43-4498-9506-ae790d45ef84');
INSERT INTO Ability(PokemonUID, AbilityUID) VALUES ('98315c60-5ea3-4460-a60a-6d6c86bb28f1','c2089431-d042-4695-869d-1c4f0d79cd78');
-- evolution link
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('3474b644-2bdd-4c9a-8b8e-d40ac47c53e6','985ecb8e-0b9a-4a42-91a9-c2ca8b404dc8',16,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('3474b644-2bdd-4c9a-8b8e-d40ac47c53e6','2654060b-4052-4197-906f-9f5f29c2a3c1',32,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('985ecb8e-0b9a-4a42-91a9-c2ca8b404dc8','2654060b-4052-4197-906f-9f5f29c2a3c1',32,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('22d794c8-a4c7-49d7-a2ce-756c6220f2e1','98315c60-5ea3-4460-a60a-6d6c86bb28f1',16,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('22d794c8-a4c7-49d7-a2ce-756c6220f2e1','e4b57b20-4560-45de-82dc-9a8e09799c40',36,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('98315c60-5ea3-4460-a60a-6d6c86bb28f1','e4b57b20-4560-45de-82dc-9a8e09799c40',36,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('a9514366-3311-4322-a709-8fed85847d52','5f733105-3ff9-4b8b-8435-08658cc3ba29',16,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('a9514366-3311-4322-a709-8fed85847d52','a6a6fbc7-3b6d-45ac-87f7-b8dc0ea8c681',36,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('5f733105-3ff9-4b8b-8435-08658cc3ba29','a6a6fbc7-3b6d-45ac-87f7-b8dc0ea8c681',36,'Leveling');
INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES('8101cb53-c19c-474d-988f-884bf5cbdaf3','2c52ec05-7ea6-4834-b757-eb87115ec9bb',7,'Leveling');
-- move link
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','6e9d86c3-6828-4645-9a64-fb3ea1713146',00);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','b1a3099f-a412-470a-9a48-822a96056608',00);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','b91bf819-c0cd-483b-8742-0630d050d6a4',08);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','96118aa2-7e78-46b1-8a15-5d59c8c14f46',12);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','f5994c7c-ad55-4eb5-b7d0-3b5c453722d3',15);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','0361c5d7-87d2-46ee-9d0d-2942b23b9ae4',22);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','ca450d6d-9891-43e7-8167-673484304177',29);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','0d8982c8-2544-48e5-81dc-d317eaf4f070',36);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','54c81705-a6a1-4ad2-aa16-15519fe64dcf',43);
INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES ('72c6f3d4-3b79-43a8-ab68-e0783f94700d','ec609f21-ddc6-477d-9e31-ac4307bd6a19',50);
-- moves
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('8030a9fb-987d-4395-9d3f-2075fb7eedeb','Pound','Normal','Physical move',40,100,35);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('a0ffa838-8f17-4149-bb88-12bd2a746f5e','Karate Chop','Fighting','Physical move',50,100,25);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('7d6d1b93-0975-42db-a805-1d5f817d94e1','DoubleSlap','Normal','Physical move',15,85,10);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('e666942f-8088-44f7-aba1-90bb355bfe88','Comet Punch','Normal','Physical move',18,85,15);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('10607821-a078-4a18-b548-729a5ac9cc28','Mega Punch','Normal','Physical move',80,85,20);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('faf1a35e-e8e6-4e2e-8113-cc8829781d07','Pay Day','Normal','Physical move',40,100,20);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('98dbd4b7-9834-4a23-ac96-ec91e157c8aa','Fire Punch','Fire','Physical move',75,100,15);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('fdb2946f-832c-473b-8eff-d1f004441b86','Ice Punch','Ice','Physical move',75,100,15);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('e941e954-9907-4922-8788-5c860f082b0c','ThunderPunch','Electric','Physical move',75,100,15);
INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES('0a5439f0-7747-462d-9260-90260aa03f5c','Scratch','Normal','Physical move',40,100,35);
-- natures
INSERT INTO Natures (GUID, Name, Effect) VALUES('455cf943-e44c-439c-9ecb-8d3f809fcfd4','Hardy','None');
INSERT INTO Natures (GUID, Name, Effect) VALUES('38a62fa2-de96-4d68-a92c-f91958769e64','Lonely','Increased Attack, Decreased Defense');
INSERT INTO Natures (GUID, Name, Effect) VALUES('3f2884b2-77cb-46c2-8739-3fa13a47b770','Brave','Increased Attack, Decreased Speed');
INSERT INTO Natures (GUID, Name, Effect) VALUES('ed28930e-5278-4772-89ab-551de8144634','Adamant','Increased Attack, Decreased Sp. Attack');
INSERT INTO Natures (GUID, Name, Effect) VALUES('24a98da8-02f0-4f74-ba58-43fdea54b949','Naughty','Increased Attack, Decreased Sp. Defense');
INSERT INTO Natures (GUID, Name, Effect) VALUES('5ff1d682-2c3d-40d2-bcbf-28887230e611','Bold','Increased Defense, Decreased Attack');
INSERT INTO Natures (GUID, Name, Effect) VALUES('dd0cb250-f939-4a33-ad41-06eab94fb951','Docile','None');
INSERT INTO Natures (GUID, Name, Effect) VALUES('175fa028-094f-4556-814d-0926558cab70','Relaxed','Increased Defense, Decreased Speed');
INSERT INTO Natures (GUID, Name, Effect) VALUES('932d9855-f743-42c1-9f07-490db76d5b7c','Impish','Increased Defense, Decreased Sp. Attack');
INSERT INTO Natures (GUID, Name, Effect) VALUES('3ba46bd8-46d8-496a-be79-0b3ef213e0c7','Lax','Increased Defense, Decreased Sp. Defense');
-- nature