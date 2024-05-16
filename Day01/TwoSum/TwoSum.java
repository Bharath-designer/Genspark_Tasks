package TwoSum;
import java.util.*;
class Solution {
    public int[] twoSum(int[] nums, int target) {
        HashMap<Integer,Integer> hmap = new HashMap<Integer, Integer>();
        int res[] = new int[2];

        for(int i = 0;i<nums.length;i++){
            if(hmap.containsKey(target - nums[i])){
                res[0] = i;
                res[1] = hmap.get(target - nums[i]);
            }else{
                hmap.put(nums[i],i);
            }
        }
        return res;
        
    }

}

class Main {
    public static void main(String[] args) {
        int[] nums = {2,7,11,15};
        int target = 9;
        Solution solution = new Solution();
        int[] result = solution.twoSum(nums, target);
        System.out.println("The output is [" + result[0] + ", " + result[1] + "]");
    }
}