const expect = require('chai').expect;
const rewire = require('rewire');
const sinon = require('sinon');
const sut = rewire('../lib/order');


describe('Ordering items', function(){
    
    beforeEach(function(){
       
        this.testData = [
            {sku: 'AAA', qty: 10},
            {sku: 'BBB', qty: 0},
            {sku: 'CCC', qty: 3}
        ]; 
        
        this.consoleMock = {
            log: sinon.spy()
        }
        
        this.warehouseMock = {
            packageAndShip: sinon.stub().yields(42) // invokes the sent sb function with argument 42
        }
        
        sut.__set__('inventoryData', this.testData);
        sut.__set__('console', this.consoleMock);
        sut.__set__('warehouse', this.warehouseMock);
        
    });
    
    
    it('Should order an item when there are enough in stock', function(done){    
                
        let _this = this;
        
        sut.order('CCC', 3, () => {
                  
            expect(_this.consoleMock.log.callCount).to.equal(2);
            done();
            
        });
        
    });
    
    describe('Warehosue interaction', function(){
        
        beforeEach(function(){
            
            this.callback = sinon.spy();
            
            sut.order('CCC', 2, this.callback);
            
        });
        
        it('receives a tracking number', function(){
            
//            let callback = sinon.spy();
//            
//            sut.order('CCC', 2, callback);
            
            expect(this.callback.calledWith(42)).to.equal(true);
        });
        
        it('package and shit called wil correct sku and qty', function(){
            
//            let callback = sinon.spy();
//            
//            sut.order('CCC', 2, callback);
            
            expect(this.warehouseMock.packageAndShip.calledWith('CCC', 2));
            
        });
        
    })
    
});