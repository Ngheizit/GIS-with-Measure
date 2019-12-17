data <- read.table("clipboard",header=T)
d=dist(scale(data),method="euclidean")
hc1=hclust(d,method="single")
                # single → 最短距离法
                # complete → 最长距离法
                # median → 中间距离法
                # average ??? 类平均法
                # centroid → 重心法
                # ward → 离差平方和法
plot(hc1,hang=-1,main="聚类谱系图")
cutree(hc1,3)
rect.hclust(hc1,k=3,border='red')
