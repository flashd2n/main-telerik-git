const supertest = require('supertest');

describe('ITEMS TESTS INTEGRATION', () => {
    let app = null;
    beforeEach(() => {
        const connectionString = 'mongodb://localhost/project-structure-training';
        return Promise.resolve()
            .then(() => {
                return require('../../database').init(connectionString);
            })
            .then((database) => {
                return require('../../data').init(database);
            })
            .then((data) => {
                return require('../../app').init(data);
            })
            .then((_app) => {
                app = _app;
            });
    });
    describe('GET', () => {
        it('expect to return 200', (done) => {
            supertest(app)
                .get('/items')
                .expect(200)
                .end((err, res) => {
                    if (err) {
                        return done(err);
                    }
                    console.log(res.text);
                    return done();
                });
        });
    });
});
