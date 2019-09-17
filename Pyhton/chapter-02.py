# -*- coding: utf-8 -*-

import math
import time

# --------------------------------------


# 全距 R （极差）
# Full Distance = Max - Min
def R(array):
    return max(array) - min(array)

# 组数 n
def NumberOfGroups(array):
    return 1 + 3.32 * math.log10(len(array))

# 组距 h = 全距 R / 组数 n
def GroupsDistance(array):
    r = R(array)
    n = NumberOfGroups(array)
    return r/n

# 组限 = min - 0.5h
def GroupLimit(array):
    return min(array) - 0.5*GroupsDistance(array)

# 平均数
def Sum(array):
    result = 0.0
    for i in array:
        result += i
    return result/len(array)

# 平均数（使用递归）
def Sum2(array, length):
    if(length == 1):
        return array[0]
    return (array[length - 1] + Sum2(array, length - 1)*(length - 1))/length

# 离差
def Deviation(array, index):
    return array[index] - Sum(array)

# 离差平方和
def DeviationOfQquareSum(array):
    result = 0.0
    i = 0
    while i < len(array):
        result += math.pow(Deviation(array, i), 2)
        i += 1
    return result

# 方差
def Variance(array):
    return 1.0/len(array)*DeviationOfQquareSum(array)

# 标准差
def StandardDeviation(array):
    return math.sqrt(Variance(array))

# 无偏估计标准擦汗
def StandardDeviationOfUnbiasedEstimation(array):
    return(math.sqrt(1.0/(len(array)-1)*DeviationOfQquareSum(array)))

# 变异系数
def CoefficientOfVariation(array):
    return StandardDeviationOfUnbiasedEstimation(array)/Sum(array)

# 偏度系数
def SkewnessCoefficient(array):
    result = 0.0
    i = 0
    while i < len(array):
        result += (1/len(array))*math.pow((array[i] - Sum(array))/StandardDeviation(array), 3)
        i += 1
    return result

# 峰度系数
def KurtosisCoefficient(array):
    result = 0.0
    i = 0
    while i < len(array):
        result += (1/len(array))*math.pow((array[i] - Sum(array))/StandardDeviation(array), 4) - 3
        i += 1
    return result


# --------------------------------------


def main():
    numbers = [12, 83, 50, 35, 55, 50, 72, 40, 85, 29, 65, 75]
    print(KurtosisCoefficient (numbers))
    pass


main()

# --------------------------------------

