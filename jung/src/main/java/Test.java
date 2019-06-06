public class Test extends Core {

    private static final String PATH = "../samples/test2.txt";
    private static final Boolean AVOID_DOUBLES = true;
    private static final Integer[] UNIQUE_TESTS = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    private static final Integer[] INDEXES = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    private static final String[] ALGORITHMS = {"bfs", "dfs", "render"};

    public static void main(String[] args) {
        run(PATH, AVOID_DOUBLES, UNIQUE_TESTS, INDEXES, ALGORITHMS);
    }
}