# 一次多项式
ds=read.table("clipboard",header=T)
fm=lm(z~x+y,data=ds)
fm
anova(fm)
summary(fm)

# 二次多项�?
ds=read.table("clipboard",header=T)
fm=lm(z~x+y+xx+yy+xy,data=ds)
fm
anova(fm)
summary(fm)

# 三次多项�?
ds=read.table("clipboard",h?ader=T)
fm=lm(z~x+y+xx+yy+xy+xxy+xyy+xxx+yyy,data=ds)
fm
anova(fm)
summary(fm)


### 模型的方差分�?(ANOVA)
anova(fm)
### 回归系数t检�?
summary(fm)
