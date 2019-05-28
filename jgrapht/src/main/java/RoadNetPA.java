public class RoadNetPA extends Core {

    private static final String PATH = "../samples/roadNet-PA.txt";
    private static final Boolean AVOID_DOUBLES = true;
    private static final Integer[] UNIQUE_TESTS = {100, 1000, 10000, 100000};
    private static final Integer[] INDEXES = {100, 1000, 10000, 100000};

    public static void main(String[] args) {
        run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES);
    }
}