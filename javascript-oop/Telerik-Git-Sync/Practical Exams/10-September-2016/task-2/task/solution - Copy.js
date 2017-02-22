'use strict';

function solve() {

    const idGenerator = (function () {
        let id = 0;
        return function () { return ++id; };
    })();

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

    const VALIDATOR = {
        validateString: function (input) {
            if (typeof input !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
        },
        validateStringLength: function (input, min, max) {
            if (input.length < min || input.length > max) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
        },
        validateStringSymbols: function (input) {
            if (!(/^[A-Za-z\s]+$/.test(input))) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        validateNumber: function (input) {
            if (typeof input !== 'number' || isNaN(input) || input <= 0) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        validateEffect: function (input) {
            if (typeof input !== 'function' || input.length !== 1) {
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
        },
        validateAlignment: function (input) {
            this.validateString(input);
            if (input !== 'good' && input !== 'neutral' && input !== 'evil') {
                throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT);
            }
        },
        validateSpeed: function (input) {
            if (typeof input !== 'number' || isNaN(input) || input <= 0 || input > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }
        },
        validateHealth: function (input) {
            if (typeof input !== 'number' || isNaN(input) || input <= 0 || input > 200) {
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
        },
        validateDamage: function (input) {
            if (typeof input !== 'number' || isNaN(input) || input <= 0 || input > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
        },
        validateCount: function (input) {
            if (typeof input !== 'number' || isNaN(input) || input < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }
        },
        validateBattleParticipant: function (participant) {
            try {
                this.validateString(participant.name);
                this.validateStringLength(participant.name, 2, 20);
                this.validateStringSymbols(participant.name);
                this.validateAlignment(participant.alignment);
                this.validateSpeed(participant.speed);
                this.validateCount(participant.count);
                this.validateDamage(participant.damage);
                this.validateHealth(participant.health);
            } catch (error) {
                throw new Error(`Battle participants must be ArmyUnit-like!`);
            }
        },
        validateSpell: function (spell) {
            try {
                VALIDATOR.validateString(spell.name);
                VALIDATOR.validateStringLength(spell.name, 2, 20);
                VALIDATOR.validateStringSymbols(spell.name);
                VALIDATOR.validateNumber(spell.manaCost);
                VALIDATOR.validateEffect(spell.effect);
            } catch (error) {
                throw new Error(`Passed objects must be Spell-like objects!`);
            }
        }
    };

    class Spell {

        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        set name(value) {
            VALIDATOR.validateString(value);
            VALIDATOR.validateStringLength(value, 2, 20);
            VALIDATOR.validateStringSymbols(value);
            this._name = value;
        }
        get name() {
            return this._name;
        }
        set manaCost(value) {
            VALIDATOR.validateNumber(value);
            this._manaCost = value;
        }
        get manaCost() {
            return this._manaCost;
        }
        set effect(value) {
            VALIDATOR.validateEffect(value);
            this._effect = value;
        }
        get effect() {
            return this._effect;
        }


    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        set name(value) {
            VALIDATOR.validateString(value);
            VALIDATOR.validateStringLength(value, 2, 20);
            VALIDATOR.validateStringSymbols(value);
            this._name = value;
        }
        get name() {
            return this._name;
        }

        set alignment(value) {
            VALIDATOR.validateAlignment(value);
            this._alignment = value;
        }
        get alignment() {
            return this._alignment;
        }
    }

    class ArmyUnit extends Unit {
        constructor(name, alignment, speed, count, damage, health) {
            super(name, alignment);
            this._id = idGenerator();
            this.speed = speed;
            this.count = count;
            this.damage = damage;
            this.health = health;
        }

        get id() {
            return this._id;
        }

        set speed(value) {
            VALIDATOR.validateSpeed(value);
            this._speed = value;
        }
        get speed() {
            return this._speed;
        }
        set count(value) {
            VALIDATOR.validateCount(value);
            this._count = value;
        }
        get count() {
            return this._count;
        }
        set damage(value) {
            VALIDATOR.validateDamage(value);
            this._damage = value;
        }
        get damage() {
            return this._damage;
        }
        set health(value) {
            VALIDATOR.validateHealth(value);
            this._health = value;
        }
        get health() {
            return this._health;
        }


    }

    class Commander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);
            this.mana = mana;
            this._spellbook = [];
            this._army = [];
        }

        get spellbook() {
            return this._spellbook;
        }
        get army() {
            return this._army;
        }
        set mana(value) {
            VALIDATOR.validateNumber(value);
            this._mana = value;
        }
        get mana() {
            return this._mana;
        }
    }

    class Battlemanager {
        constructor() {
            this._allCommanders = [];
            this._allArmy = [];
        }

        get allCommanders() {
            return this._allCommanders;
        }
        get allArmy() {
            return this._allArmy;
        }

        getCommander(name, alignment, mana) {
            return new Commander(name, alignment, mana);
        }

        getArmyUnit(options) {

            let newUnit = new ArmyUnit(options.name, options.alignment, options.speed, options.count, options.damage, options.health);
            this.allArmy.push(newUnit);
            return newUnit;
        }

        getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        }

        addCommanders(...commanders) {
            this.allCommanders.push(...commanders);
            return this;
        }

        addArmyUnitTo(commanderName, unit) {
            this.allCommanders.find(x => x.name === commanderName).army.push(unit);
            return this;
        }

        addSpellsTo(commanderName, ...spells) {

            spells.forEach(x => VALIDATOR.validateSpell(x));

            this.allCommanders.find(x => x.name === commanderName).spellbook.push(...spells);
            return this;
        }

        findCommanders(query) {

            return this.allCommanders.filter(function (commander) {
                return (!query.hasOwnProperty('name') || query.name === commander.name) && (!query.hasOwnProperty('alignment') || query.alignment === commander.alignment);
            }).slice().sort(function (x, y) {
                if (x.name > y.name) {
                    return 1;
                } else if (x.name < y.name) {
                    return -1;
                } else {
                    return 0;
                }
            });

        }

        findArmyUnitById(idToFind) {
            return this.allArmy.find(x => x.id === idToFind);
        }

        findArmyUnits(query) {

            let foundArmy = this.allArmy.filter(function (x) {
                return (!query.hasOwnProperty('id') || query.id === x.id) && (!query.hasOwnProperty('name') || query.name === x.name) && (!query.hasOwnProperty('alignment') || query.alignment === x.alignment);
            });

            return foundArmy.sort(
                function (x, y) {
                    if (x.speed !== y.speed) {
                        return y.speed - x.speed;
                    } else {
                        if (x.name > y.name) {
                            return 1;
                        } else if (x.name < y.name) {
                            return -1;
                        } else {
                            return 0;
                        }
                    }
                }
            );

        }

        spellcast(casterName, spellName, targetUnitId) {

            let commanderToCast = this.allCommanders.find(x => x.name === casterName);

            if (commanderToCast === undefined) {
                throw new Error(`Cannot cast with non-existant commander ${casterName}`);
            }

            let spellToCast = commanderToCast.spellbook.find(x => x.name === spellName);

            if (spellToCast === undefined) {
                throw new Error(`${casterName} does not know ${spellName}`)
            }

            if (commanderToCast.mana < spellToCast.manaCost) {
                throw new Error(`Not enough mana!`);
            }

            let target = this.allArmy.find(x => x.id === targetUnitId);

            if (target === undefined) {
                throw new Error(`Target not found!`);
            }

            let spellToCastEffect = spellToCast.effect;

            spellToCastEffect(target);

            commanderToCast.mana -= spellToCast.manaCost;

            return this;

        }

        battle(attacker, defender) {
            VALIDATOR.validateBattleParticipant(attacker);
            VALIDATOR.validateBattleParticipant(defender);

            let totalDamage = attacker.damage * attacker.count;
            let totalHealth = defender.health * defender.count;
            totalHealth -= totalDamage;

            if(totalHealth <= 0){
                defender.count = 0;
                return this;
            }

            defender.count = Math.ceil(totalHealth / defender.health);

            return this;
        }

    }

    return new Battlemanager();
}

module.exports = solve;