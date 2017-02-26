'use strict';

function solve() {

	const uploadOrderGenerator = (function () {
		let order = 0;
		return function () {
			return ++order;
		};
	})();

	const VALIDATOR = {
		validateString: function (input) {
			if (typeof input !== 'string' || input === undefined || input === null) {
				throw new Error('This is not a string');
			}
		},
		validateName: function (input) {
			this.validateString(input);
			if (input.length < 1 || input.length > 24) {
				throw new Error('The string is not within the permited length limit');
			}
			if (!(/^[A-Za-z\d\s]+$/.test(input))) {
				throw new Error('The string contains unvalid characters');
			}
		},
		validatePositiveNumber: function (input) {
			if (typeof input !== 'number' || isNaN(input) || input <= 0) {
				throw new Error('The provided number is not a number or is not positive');
			}
		},
		validateNumberRange: function (input, min, max) {
			if (typeof input !== 'number' || isNaN(input) || input < min || input > max) {
				throw new Error('The provided number is not a number or is not within the permited limits');
			}
		},
		validatePassedVersionNumber: function (input, currentValue) {
			this.validatePositiveNumber(input);
			if (input <= currentValue) {
				throw new Error('The passed version is lower than the current');
			}
		},
		validatePassedVersionObject: function (input, currentValue) {
			if (!input.hasOwnProperty('version')) {
				throw new Error('Passed object does not have property version');
			}
			this.validatePassedVersionNumber(input.version, currentValue);

			if (input.hasOwnProperty('description')) {
				this.validateString(input.description);
			}

			if (input.hasOwnProperty('rating')) {
				this.validateNumberRange(input.rating, 1, 10);
			}

		},
		validatePassedApp: function (input) {
			if (!(input instanceof App)) {
				throw new Error('Passed App is not an instance of App class');
			}
			// if(input.hasOwnProperty('_apps')){
			// 	throw new Error('Passed App is not an instance of App class');
			// }
		},
		validateHostName: function (input) {
			this.validateString(input);
			if (input.length < 1 || input.length > 32) {
				throw new Error('The string is not within the permited length limit');
			}
		},
		validatePassedApps: function (input) {
			try {
				input.forEach(function (x) {
					VALIDATOR.validateName(x.name);
					VALIDATOR.validateString(x.description);
					VALIDATOR.validatePositiveNumber(x.version);
					VALIDATOR.validateNumberRange(x.rating, 1, 10);
				});
			} catch (error) {
				throw new Error('Passed Array contains an invalid App');
			}
		}
	};

	class App {
		constructor(name, description, version, rating) {
			this.name = name;
			this.description = description;
			this.version = version;
			this.rating = rating;
			this._upload = -1;
		}

		get upload() {
			return this._upload;
		}

		get name() {
			return this._name;
		}
		set name(value) {
			VALIDATOR.validateName(value);
			this._name = value;
		}
		get description() {
			return this._description;
		}
		set description(value) {
			VALIDATOR.validateString(value);
			this._description = value;
		}
		get version() {
			return this._version;
		}
		set version(value) {
			VALIDATOR.validatePositiveNumber(value);
			this._version = value;
		}
		get rating() {
			return this._rating;
		}
		set rating(value) {
			VALIDATOR.validateNumberRange(value, 1, 10);
			this._rating = value;
		}

		release(input) {
			let currentVersion = this.version;

			if (typeof input === 'object') {

				VALIDATOR.validatePassedVersionObject(input, currentVersion);
				this.version = input.version;

				if (input.hasOwnProperty('description')) {
					this.description = input.description;
				}
				if (input.hasOwnProperty('rating')) {
					this.rating = input.rating;
				}
				return this;
			}

			VALIDATOR.validatePassedVersionNumber(input, currentVersion);
			this.version = input;

			return this;
		}

	}

	class Store extends App {
		constructor(name, description, version, rating) {
			super(name, description, version, rating);
			this._apps = [];
		}

		get apps() {
			return this._apps;
		}

		uploadApp(app) {
			VALIDATOR.validatePassedApp(app);

			let foundApp = this.apps.find(x => x.name === app.name);

			if (foundApp === undefined) {
				let appToUpload = new App(app.name, app.description, app.version, app.rating);
				appToUpload._upload = uploadOrderGenerator();
				this.apps.push(appToUpload);
				return this;
			}

			if (app.version <= foundApp.version) {
				throw new Error('The new version is not bigger than the old one');
			}

			foundApp.version = app.version;
			foundApp.description = app.description;
			foundApp.rating = app.rating;

			return this;
		}

		takedownApp(name) {

			let indextoRemove = this.apps.findIndex(x => x.name === name);

			if (indextoRemove < 0) {
				throw new Error('The app does not exist in the sotre');
			}

			this.apps.splice(indextoRemove, 1);

			return this;

		}

		search(pattern) {
			VALIDATOR.validateString(pattern);

			return this.apps.filter(function (x) {
				if (x.name.toLowerCase().indexOf(pattern.toLowerCase()) < 0) {
					return false;
				}
				return true;
			}).sort(function (x, y) {
				if (x.name > y.name) {
					return 1;
				} else if (x.name < y.name) {
					return -1;
				} else {
					return 0;
				}
			});

		}

		listMostRecentApps(count) {
			let countToReturn = count || 10;

			return this.apps.slice().sort((x, y) => y.upload - x.upload).slice(0, countToReturn);

		}

		listMostPopularApps(count) {

			let countToReturn = count || 10;

			return this.apps.slice().sort(function (x, y) {
				if (x.rating === y.rating) {
					return y.upload - x.upload;
				}
				return y.rating - x.rating;
			}).slice(0, countToReturn);

		}
	}

	class Device {
		constructor(hostname, apps) {
			this.hostname = hostname;
			this.apps = apps;
		}

		get hostname() {
			return this._hostname;
		}
		set hostname(value) {
			VALIDATOR.validateHostName(value);
			this._hostname = value;
		}

		get apps() {
			return this._apps;
		}

		set apps(value) {
			VALIDATOR.validatePassedApps(value);
			this._apps = value;
		}

		search(pattern) {

			let appsToReturn = [];
			let allStores = this.apps.filter(x => x.hasOwnProperty('_apps'));

			allStores.forEach(function (store) {
				store.apps.forEach(function (app) {
					if (app.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0) {
						appsToReturn.push(app);
					}
				});
			});

			appsToReturn.sort(function (x, y) {
				if (x.name > y.name) {
					return 1;
				} else if (x.name < y.name) {
					return -1;
				} else {
					return 0;
				}
			});

			let result = [];
			let isAdded = -1;

			for (let i = 0; i < appsToReturn.length; i++) {

				isAdded = result.findIndex(x => x.name === appsToReturn[i].name);

				if (isAdded >= 0) {

					if (result[isAdded].version < appsToReturn[i].version) {
						result[isAdded].version = appsToReturn[i].version;
					}

				} else {
					result.push(appsToReturn[i]);
				}

			}

			return result;

		}

		install(name) {

			let foundApps = [];
			let allStores = this.apps.filter(x => x.hasOwnProperty('_apps'));

			allStores.forEach(function (store) {
				store.apps.forEach(function (app) {
					if (app.name === name) {
						foundApps.push(app);
					}
				});
			});

			if (foundApps.length === 0) {
				throw new Error('App not found in stores');
			}

			foundApps.sort(function (x, y) {
				return y.version - x.version;
			});

			let appToInstall = foundApps[0];

			if (this.apps.some(x => x.name === appToInstall.name)) {
				return this;
			}

			this.apps.push(appToInstall);

			return this;
		}

		uninstall(name) {

			let indexToRemove = -1;

			for (let i = 0; i < this.apps.length; i++) {

				if (this.apps[i].hasOwnProperty('_apps`')) {
					continue;
				}

				if (this.apps[i].name === name) {
					indexToRemove = i;
					break;
				}

			}

			if (indexToRemove < 0) {
				throw new Error('no such app is found');
			}

			this.apps.splice(indexToRemove, 1);

			return this;
		}

		listInstalled() {

			return this.apps.slice().sort(function (x, y) {
				if (x.name > y.name) {
					return 1;
				} else if (x.name < y.name) {
					return -1;
				} else {
					return 0;
				}
			});

		}

		update() {

			let allStores = this.apps.filter(x => x.hasOwnProperty('_apps'));
			// let allInstalledApps = this.apps.filter(x => !x.hasOwnProperty('_apps'));

			this.apps.forEach(function (app) {

				allStores.forEach(function (store) {

					store.apps.forEach(function (appInStore) {

						if (appInStore.name === app.name && appInStore.version > app.version) {
							app.version = appInStore.version;
						}
					});

				});

			});

			return this;
		}


	}

	return {
		createApp(name, description, version, rating) {
			return new App(name, description, version, rating);
		},
		createStore(name, description, version, rating) {
			return new Store(name, description, version, rating);
		},
		createDevice(hostname, apps) {
			return new Device(hostname, apps);
		}
	};
}

// Submit the code above this line in bgcoder.com
module.exports = solve;
