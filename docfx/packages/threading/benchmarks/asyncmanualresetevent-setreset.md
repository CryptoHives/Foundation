| Method                               | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |-----------:|------:|----------:|------------:|
| ManualResetEventSlimSet              |   5.850 ns |  0.71 |         - |          NA |
| PooledAsyncManualResetEventSetReset  |   8.243 ns |  1.00 |         - |          NA |
| RefImplAsyncManualResetEventSetReset |  10.641 ns |  1.29 |      96 B |          NA |
| NitoAsyncManualResetEventSetReset    |  19.161 ns |  2.32 |      96 B |          NA |
| ManualResetEventSet                  | 453.439 ns | 55.01 |         - |          NA |
