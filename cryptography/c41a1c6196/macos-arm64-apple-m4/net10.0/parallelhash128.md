| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     517.9 ns |     2.07 ns |     1.93 ns |     517.3 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  30,480.5 ns |   602.18 ns | 1,465.80 ns |  30,667.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     519.9 ns |     1.86 ns |     1.74 ns |     520.1 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  30,550.2 ns |   608.91 ns | 1,284.40 ns |  30,888.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   1,421.6 ns |     1.75 ns |     1.46 ns |   1,421.3 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  31,935.8 ns |   625.08 ns | 1,219.18 ns |  32,095.5 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   1,433.0 ns |     3.75 ns |     3.50 ns |   1,432.6 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  32,012.6 ns |   634.76 ns | 1,779.93 ns |  32,887.1 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |   7,751.7 ns |    21.95 ns |    20.53 ns |   7,752.0 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,538.6 ns |   821.05 ns | 1,521.87 ns |  42,200.5 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 118,846.0 ns |   344.85 ns |   322.57 ns | 118,919.4 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 229,482.5 ns | 1,294.27 ns | 1,210.66 ns | 229,783.3 ns |     128 B |