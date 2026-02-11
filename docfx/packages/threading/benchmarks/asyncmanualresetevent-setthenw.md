| Method                                            | Mean     | Ratio | Allocated | 
|-------------------------------------------------- |---------:|------:|----------:|
| RefImplAsyncManualResetEventSetThenWaitAsync      | 13.32 ns |  0.81 |      96 B | 
| PooledAsyncManualResetEventSetThenWaitAsync       | 16.47 ns |  1.00 |         - | 
| PooledAsTaskAsyncManualResetEventSetThenWaitAsync | 17.12 ns |  1.04 |         - | 
| NitoAsyncManualResetEventSetThenWaitAsync         | 24.06 ns |  1.46 |      96 B |