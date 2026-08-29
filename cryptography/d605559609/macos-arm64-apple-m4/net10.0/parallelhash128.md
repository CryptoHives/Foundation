| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     622.9 ns |     0.34 ns |     0.29 ns |     622.9 ns |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  27,425.8 ns |   819.81 ns | 2,417.22 ns |  28,768.4 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     624.3 ns |     0.90 ns |     0.80 ns |     624.0 ns |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  27,227.6 ns |   859.41 ns | 2,533.98 ns |  28,757.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   1,600.0 ns |     0.68 ns |     0.57 ns |   1,600.1 ns |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  24,987.4 ns | 1,828.72 ns | 5,392.01 ns |  26,746.0 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   1,596.2 ns |     1.70 ns |     1.42 ns |   1,596.7 ns |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  27,012.1 ns |   798.96 ns | 2,355.76 ns |  27,484.2 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |   8,442.0 ns |     6.74 ns |     5.98 ns |   8,441.0 ns |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  37,767.2 ns | 1,220.19 ns | 3,597.77 ns |  38,642.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 140,248.0 ns |   735.57 ns |   614.24 ns | 140,206.7 ns |  263336 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 229,326.7 ns | 1,099.25 ns | 1,028.24 ns | 229,451.6 ns |     128 B |