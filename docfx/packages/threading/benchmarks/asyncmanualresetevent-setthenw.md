| Method                                            | Mean     | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------------- |---------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventSetThenWaitAsync      | 14.64 ns |  0.84 |      96 B |          NA |
| PooledAsyncManualResetEventSetThenWaitAsync       | 17.42 ns |  1.00 |         - |          NA |
| PooledAsTaskAsyncManualResetEventSetThenWaitAsync | 18.27 ns |  1.05 |         - |          NA |
| NitoAsyncManualResetEventSetThenWaitAsync         | 25.83 ns |  1.48 |      96 B |          NA |
