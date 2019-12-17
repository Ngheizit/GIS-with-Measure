options(digits = 20) # 设置统计结果小数显示位数

data <- readClipboard()
data <- as.numeric(data)
data

mean(data) # 平均值
sort(data, decreasing = F) # 升序排列 T升序 F降序
median(data) # 中位数
var(data) # 方差 - 无偏估计
sd(data) # 标准差 - 无偏估计
1*sd(data)/mean(data) # 变异系数

library(moments)
install.packages("moments")
skewness(data) # 偏度系数
kurtosis(data)-3 # 峰度系数
