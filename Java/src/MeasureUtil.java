import java.util.Random;

public class MeasureUtil {



    public static void main(String[] args){
        int height;
        for (int i = 0; i < 20; i++){
            while (true){
                height = new Random().nextInt(20);
                if(height> 5){
                    break;
                }
            }
            System.out.println(height);
        }
    }
}
