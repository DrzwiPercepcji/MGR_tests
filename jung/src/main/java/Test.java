public class Test extends Core {

    private static final String PATH = "../samples/test.txt";
    private static final Boolean AVOID_DOUBLES = true;
    private static final Integer[] UNIQUE_TESTS = {0, 1, 2, 3, 4, 5, 6};
    private static final Integer[] INDEXES = {0, 1, 2, 3, 4, 5, 6};

    public static void main(String[] args) {
        run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES);
    }
}