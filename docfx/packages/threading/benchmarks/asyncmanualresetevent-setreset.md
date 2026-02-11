| Method                               | Mean       | Ratio | Allocated | 
|------------------------------------- |-----------:|------:|----------:|
| ManualResetEventSlimSetReset         |   5.538 ns |  0.70 |         - | 
| PooledAsyncManualResetEventSetReset  |   7.868 ns |  1.00 |         - | 
| RefImplAsyncManualResetEventSetReset |  10.349 ns |  1.32 |      96 B | 
| NitoAsyncManualResetEventSetReset    |  17.505 ns |  2.23 |      96 B | 
| ManualResetEventSetReset             | 432.514 ns | 54.98 |         - |