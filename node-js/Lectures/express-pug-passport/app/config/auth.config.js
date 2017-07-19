const passport = require('passport');
const { Strategy } = require('passport-local');
const cookieParser = require('cookie-parser');
const session = require('express-session');
const MongoStore = require('connect-mongo')(session);


const config = (app, { users }, db) => {
    app.use(cookieParser());
    app.use(session({
        secret: 'Awesome Stuff',
        maxAge: new Date(Date.now() + 60 * 60 * 1000),
        store: new MongoStore({ db }, (err) => {
            console.log(err.message);
        }),
     }));
    app.use(passport.initialize());
    app.use(passport.session());

    passport.use(new Strategy(
        (username, password, done) => {
            users.findByUsername(username)
                .then((user) => {
                    done(null, user);
                })
                .catch((err) => {
                    done(err);
                });
        }
    ));

    passport.serializeUser((user, done) => {
        done(null, user.id);
    });

    passport.deserializeUser((id, done) => {
        users.findById(id)
            .then((user) => {
                done(null, user);
            })
            .catch((err) => {
                done(err);
            });
    });
};

module.exports = config;
