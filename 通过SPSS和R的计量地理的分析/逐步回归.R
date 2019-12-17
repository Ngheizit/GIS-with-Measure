help('step')


ds=read.table("clipboard",header=T)

tlm <- lm(z~x+y+xx+yy+xy, data=ds)
summary(tlm)
tstep <- step(tlm)
summary(tstep)
tstep <- step(tstep)

tlm <- lm(z~x+xx+yy+xy+xxy+xyy+xxx+yyy, data=ds)
summary(tlm)
tstep <- step(tlm)

tlm<-lm(Y~x1+x2,da?a=ds)
summary(tlm)
