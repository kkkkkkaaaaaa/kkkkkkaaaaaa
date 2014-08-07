function add(a: number, b: number) {
    return a + b;
}

describe("add", () => {
    var doNothing = () => {};

    beforeEach(() => {

        doNothing();
    });

    it("", () => {
        expect(add(1, 1))
            .not
            .toBe(2);

    });
});