'use strict';

function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!',
        INVALID_ALIGNMENT: 'Alignment must be good, neutral or evil!'
    };

    const VALIDATION = {
        isString: function (str) {
            if (typeof str !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE); // OK?
            }
        },
        stringRangeLength: function (str, min, max) {
            if (str.length < min || str.length > max) { // ok
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
        },
        strSymbolsValidate: function (str) { //ok
            if (!(/^[A-Za-z\s]+$/.test(str))) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        manaPositiveInteger: function (value) {
            if (typeof value !== 'number' || isNaN(value) || value < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        effectIsFunction: function (value) {
            if (typeof value !== 'function' || value.length !== 1) {
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
        },
        correctAlignment: function (str) {
            if (typeof str !== 'string' || str !== 'good' && str !== 'neutral' && str !== 'evil') {
                throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT);
            }
        },
        speedIsPositiveNumberLessThan100: function (n) {
            if (typeof n !== 'number' || isNaN(n) || n < 0 || n > 100) { //ok?
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }
        },
        countIsPositiveIntegerNumber: function (n) {
            if (typeof n !== 'number' || isNaN(n) || n < 0) { //ok?
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }
        },
        damageIsPositiveNumberLessThan100: function (n) {
            if (typeof n !== 'number' || isNaN(n) || n < 0 || n > 100) { //ok?
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
        },
        healtIsPositiveNumberLessThan200: function (n) {
            if (typeof n !== 'number' || isNaN(n) || n <= 0 || n > 200) { //ok?
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH); //
            } // 
        },
        validateSpellLikeObject: function (value) {
            try {
                this.isString(value.name);
                this.stringRangeLength(value.name, 2, 20);
                this.strSymbolsValidate(value.name);
                this.manaPositiveInteger(value.manaCost);
                this.effectIsFunction(value.effect);

            } catch (e) {

                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
        },
        validateBattle: function (value) {
            try {
                this.isString(value.name);
                this.stringRangeLength(value.name, 2, 20);
                this.strSymbolsValidate(value.name);
                this.correctAlignment(value.alignment);
                this.speedIsPositiveNumberLessThan100(value.speed);
                this.countIsPositiveIntegerNumber(value.count);
                this.damageIsPositiveNumberLessThan100(value.damage);
                this.healtIsPositiveNumberLessThan200(value.health);
            } catch (e) {
                throw new Error('Battle participants must be ArmyUnit-like!');
            }
        }

    }

    const getUniqueId = (function () {
        let id = 0;

        return function () {
            ++id;

            return id;
        }
    })();


    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            VALIDATION.isString(value);
            VALIDATION.stringRangeLength(value, 2, 20);
            VALIDATION.strSymbolsValidate(value);
            this._name = value;
        }

        get manaCost() {
            return this._manaCost;
        }

        set manaCost(value) {
            VALIDATION.manaPositiveInteger(value);
            this._manaCost = value;
        }

        get effect() {
            return this._effect;
        }

        set effect(value) {
            VALIDATION.effectIsFunction(value); //ok?
            this._effect = value;
        }
    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            VALIDATION.isString(value);
            VALIDATION.stringRangeLength(value, 2, 20);
            VALIDATION.strSymbolsValidate(value);
            this._name = value;
        }

        get alignment() {
            return this._alignment;
        }

        set alignment(value) {
            VALIDATION.correctAlignment(value);
            this._alignment = value;
        }
    }

    class ArmyUnit extends Unit {
        constructor(name, alignment, speed, count, damage, health) { //ok.
            super(name, alignment);
            this._id = getUniqueId();
            this.speed = speed;
            this.count = count;
            this.damage = damage;
            this.health = health;
        }

        get id() {
            return this._id;
        }

        get speed() {
            return this._speed;
        }

        set speed(value) {
            VALIDATION.speedIsPositiveNumberLessThan100(value);
            this._speed = value;
        }

        get count() {
            return this._count;
        }

        set count(value) {
            VALIDATION.countIsPositiveIntegerNumber(value);
            this._count = value;
        }

        get damage() {
            return this._damage;
        }

        set damage(value) {
            VALIDATION.damageIsPositiveNumberLessThan100(value);
            this._damage = value;
        }

        get health() {
            return this._health;
        }

        set health(value) {
            VALIDATION.healtIsPositiveNumberLessThan200(value);
            this._health = value;
        }
    }

    class Commander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);
            this.mana = mana;
            this._spellbook = [];
            this._army = [];
        }

        get mana() {
            return this._mana;
        }

        set mana(value) {
            VALIDATION.manaPositiveInteger(value);
            this._mana = value;
        }

        get spellbook() {
            return this._spellbook;
        }

        get army() {
            return this._army;
        }
    }

    class Battlemanager {
        constructor() {
            this._commanders = [];
            this._armyUnits = []; //ok :D
        }

        get commanders() {
            return this._commanders;
        }

        get armyUnits() {
            return this._armyUnits;
        }
        getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        }
        getArmyUnit(options) {
            const { name, alignment, speed, count, damage, health } = options;
            let unit = new ArmyUnit(name, alignment, speed, count, damage, health);
            this.armyUnits.push(unit);
            return unit;
        }

        getCommander(name, alignment, mana) {
            return new Commander(name, alignment, mana);
        }

        addCommanders(...commanders) {
            this.commanders.push(...commanders);
            return this;
        }

        addArmyUnitTo(commanderName, armyUnit) {
            // ами 1-во да напавя цикъл за да намеря имената на командирите, които са добавени и дали този командир го има в този масив?
            // след като го намерим. добавяме armyUnit в масива army?

            // this.commanders.find(c => c.name === commanderName)//ok
            // .army.push(armyUnit);


            for (let i = 0; i < this.commanders.length; i++) { // ups
                if (this.commanders[i].name === commanderName) {
                    this.commanders[i].army.push(armyUnit);
                    break;
                }
            }

            return this;
        }

        addSpellsTo(commanderName, ...spells) {
            spells.forEach(spell => VALIDATION.validateSpellLikeObject(spell));
            this.commanders.find(c => c.name === commanderName)
                .spellbook.push(...spells); //

            return this;
        }

        findCommanders(query) {
            // 1-во ще проверим дали query има property name или alignment
            // и върнатата стойност я сортираме по name, като преди това си направим масив или копираме този масив, в който да ги изкараме
            //  ще си направя отделен метод, в който да проверя какви пропъртита има и какво да върна ?
            // без помощни масиви
            // целия масив
            return this.commanders
                .filter(function (commander) {
                    return (!query.hasOwnProperty('name') || query.name === commander.name) &&
                        (!query.hasOwnProperty('alignment') || query.alignment === commander.alignment) // ок
                })
                .slice()
                .sort(function (a, b) {
                    if (a.name > b.name) {
                        return 1;
                    }
                    if (b.name > a.name) {
                        return -1;
                    }
                    return 0;
                }); // ok
        }

        findArmyUnitById(id) {
            return this.armyUnits
                .find(x => x.id === id); // 2 reda

        }

        findArmyUnits(query) {
            return this.armyUnits
                .filter(function (x) {
                    return (!query.hasOwnProperty('id') || query.id === x.id) &&
                        (!query.hasOwnProperty('name') || query.name === x.name) &&
                        (!query.hasOwnProperty('alignment') || query.alignment === x.alignment) ///chakam da mi se skarash :Damage
                })
                .slice()
                .sort(function (a, b) {
                    let tmp = b.speed - a.speed;
                    if (tmp === 0) {
                        if (a.name > b.name) {
                            return 1;
                        }

                        if (b.name > a.name) {
                            return -1;
                        }
                        return 0;
                    }

                    return tmp;
                }); // chestno ne znam kakvo napisah :D
        }

        spellcast(casterName, spellName, targetUnitId) {
            let commander = this.commanders
                .find(c => c.name === casterName);
            if (commander === undefined) {
                throw new Error(`Cannot cast with non-existant commander ${casterName}`);
            }
            let spell = commander.spellbook
                .find(s => s.name === spellName); // 
            if (spell === undefined) {
                throw new Error(`${casterName} does not know ${spellName}`);
            }

            if (commander.mana < spell.manaCost) {
                throw new Error(ERROR_MESSAGES.NOT_ENOUGH_MANA);
            }


            let armyUnit = this.armyUnits
                .find(x => x.id === targetUnitId);

            if (armyUnit === undefined) {
                throw new Error(ERROR_MESSAGES.TARGET_NOT_FOUND);
            }

            let spellEffect = spell.effect;
            spellEffect(armyUnit);
            commander.mana -= spell.manaCost;

            return this;
            // ok :D male naistina zabih :D
        }

        battle(attacker, defender) {
            VALIDATION.validateBattle(attacker);
            VALIDATION.validateBattle(defender); // :D
            let totalDamage = attacker.damage * attacker.count;
            let totalHealth = defender.health * defender.count;
            totalHealth -= totalDamage;
            if (totalHealth <= 0) {
                defender.count = 0;
            } else {
                defender.count = Math.ceil(totalHealth / defender.health);
            }

            return this;
        }
    }


    // your implementation goes here

    return new Battlemanager();

}

module.exports = solve;