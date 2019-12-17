# 正太总体均值的假设检�? T检�? 示例1
## 某种元件的寿命X（小时），服从正态分布，N（mu,σ2�?
## 其中mu,σ2均未知，16只元件的寿命如下�?
## 问是否有理由认为元件的平均寿命大�?255小时
data<-c(?59, 280, 101, 212, 224, 379, 179, 264,
        222, 362, 168, 250, 149, 260, 485, 170)
t.test(data, alternative = "greater", mu = 225)


# 正太总体方差的假设检�? F检�? 示例2
X<-c(78.1,72.4,76.2,74.3,77.4,78.4,76.0,75.5,76.7,77.3)
Y<-c(79.1,8?.0,77.3,79.1,80.0,79.1,79.1,77.3,80.2,82.1)
var.test(X,Y)

# 上海和北京GDP
gdp_sh <- c(2462.57, 2902.2, 3360.21, 3688.2, 4034.96, 4551.15)
gdp_bj <- c(1615.71, 181?.09, 2011.31, 2174.46, 2478.76, 2845.65)
# F检�?
var.test(gdp_sh, gdp_bj)
# 上海�???��京人�?
pop_sh <- c(1301.37, 1304.43, 1305.46, 1306.58, 1313.12, 1321.63)
pop_bj <- c(1184, 1217, 1223.4, 1249.9, 1278, 1366.4)
# F检�?
var.test(pop_sh, pop_bj)







gdp_BJ <- readClipboard()
gdp_BJ <- as.numeric(gdp_BJ)
gdp_SH <- readClipboard()
g?p_SH <- as.numeric(gdp_SH)
pop_BJ <- readClipboard()
pop_BJ <- as.numeric(pop_BJ)
pop_SH <- readClipboard()
pop_SH <- as.numeric(pop_SH)
gdp_BJ
gdp_SH
pop_SH
pop_BJ
var.test(gdp_BJ, gdp_SH)
var.test(pop_BJ, pop_SH)


options(digits = 20) # ����ͳ�ƽ��С��???ʾλ��
data <- readClipboard()
data <- as.numeric(data)
data
t.test(data, alternative = "greater", mu = 1140.488)

data <- readClipboard()
data <- as.numeric(data)
data
data2 <- readClipboard()
data2 <- as.numeric(data2)
data2
help("t.test")
t.test(data,da?a2,var.equal = T, alternative="less")
var.test(data,data2)
t.test(data,data2,paired = T)


ds=read.table("clipboard",header=T)


data <- readClipboard()
data <- as.numeric(data)
data
data2 <- readClipboard()
data2 <- as.numeric(data2)
data2
cor.test(data,d?ta2)
