| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     2.044 μs | 0.0031 μs | 0.0029 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     4.173 μs | 0.0145 μs | 0.0136 μs |    3416 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     2.018 μs | 0.0019 μs | 0.0018 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     4.124 μs | 0.0107 μs | 0.0100 μs |    3264 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    13.067 μs | 0.0196 μs | 0.0183 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    23.811 μs | 0.0502 μs | 0.0445 μs |    8792 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    12.989 μs | 0.0076 μs | 0.0067 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    23.759 μs | 0.0389 μs | 0.0325 μs |    7744 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   100.681 μs | 0.0882 μs | 0.0782 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   181.680 μs | 0.6825 μs | 0.6384 μs |   51800 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   100.696 μs | 0.0842 μs | 0.0788 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   181.665 μs | 0.4733 μs | 0.4427 μs |   43584 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 1,610.494 μs | 5.4026 μs | 4.7892 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 2,918.760 μs | 6.3356 μs | 5.6164 μs |  789104 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 1,606.659 μs | 1.4496 μs | 1.3559 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 2,887.253 μs | 5.0785 μs | 4.7505 μs |  657984 B |