abstract class Animal {

    // private readonly name: string;

    // public constructor(name: string) {
    //     this.name = name;
    // }

    public constructor(private readonly name: string) {
        // this.name = name;
    }

    public get Name() {
        return this.name;
    }

    // public set Name(value: string){
    //     this.name = value;
    // }

    public move(distanceInMeters: number = 0) {
        console.log(`${this.name} moved ${distanceInMeters} meters!`);
    }
}

class Snake extends Animal {
    public constructor(name: string) {
        super(name);
    }

    public move(distanceInMeters: number = 5) {
        console.log('Slithering...');
        super.move(distanceInMeters);
    }
}

// let sam = new Snake('Pesho');
// let otherSam: Animal = new Snake('Gosho');

let testMe = new Snake('Pesho');
// testMe.Name = 'Gosho';
let whatName = testMe.Name;
