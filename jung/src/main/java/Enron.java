public class Enron extends Core {

    private static final String PATH = "../samples/Email-Enron.txt";
    private static final Boolean AVOID_DOUBLES = true;
    private static final Integer[] UNIQUE_TESTS = {100, 1000, 10000};
    private static final Integer[] INDEXES = {100, 1000, 10000};

    public static void main(String[] args) {
        run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES);
    }
}