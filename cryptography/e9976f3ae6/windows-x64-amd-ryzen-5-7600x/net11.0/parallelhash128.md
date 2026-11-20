| Description                                           | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     767.1 ns |   2.73 ns |   2.28 ns |  20,329 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  19,118.7 ns |  22.97 ns |  19.18 ns |  23,249 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     764.3 ns |   1.81 ns |   1.61 ns |  13,795 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  19,062.5 ns |  79.12 ns |  74.01 ns |  16,724 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,169.0 ns |  17.22 ns |  16.11 ns |  13,795 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  22,148.8 ns |  31.19 ns |  27.65 ns |  23,158 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,159.9 ns |   7.66 ns |   6.40 ns |  20,130 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  21,631.2 ns |  13.68 ns |  11.42 ns |  16,823 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  11,864.6 ns |  18.27 ns |  16.20 ns |  20,322 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,416.5 ns | 515.38 ns | 430.37 ns |  25,370 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 181,555.1 ns | 524.47 ns | 464.93 ns |  13,797 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 371,709.0 ns | 950.07 ns | 793.36 ns |  25,696 B |     128 B |