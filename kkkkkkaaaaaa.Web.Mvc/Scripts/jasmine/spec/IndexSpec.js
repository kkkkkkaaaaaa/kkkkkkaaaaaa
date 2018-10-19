function add(a, b) {
    return a + b;
}
describe("add", function () {
    var doNothing = function () { };
    beforeEach(function () {
        doNothing();
    });
    it("", function () {
        expect(add(1, 1))
            .not
            .toBe(2);
    });
});
//# sourceMappingURL=IndexSpec.js.map