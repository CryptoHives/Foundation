| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     487.0 ns |     4.21 ns |     3.73 ns |  11,892 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     502.2 ns |     0.27 ns |     0.24 ns |  13,866 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     638.5 ns |     4.13 ns |     3.66 ns |   5,190 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     488.4 ns |     2.96 ns |     2.31 ns |  11,880 B |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     501.8 ns |     0.09 ns |     0.08 ns |  14,267 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     638.0 ns |     5.76 ns |     5.11 ns |   5,191 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   2,320.0 ns |     0.34 ns |     0.30 ns |  14,057 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,701.5 ns |    53.27 ns |    47.23 ns |   5,557 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   3,498.4 ns |     8.09 ns |     6.76 ns |   5,192 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   2,321.7 ns |     0.32 ns |     0.28 ns |  14,057 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,718.0 ns |    41.04 ns |    36.39 ns |  12,073 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   3,502.7 ns |     5.26 ns |     4.40 ns |   5,193 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  16,862.4 ns |     1.93 ns |     1.71 ns |   6,863 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  20,388.7 ns |   270.33 ns |   239.64 ns |  11,892 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  26,068.6 ns |   137.09 ns |   128.23 ns |   5,204 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 266,235.3 ns |    28.63 ns |    23.91 ns |   6,863 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 325,982.2 ns | 6,492.24 ns | 5,755.20 ns |   5,567 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 412,795.6 ns | 1,505.99 ns | 1,335.02 ns |   5,572 B |         - |