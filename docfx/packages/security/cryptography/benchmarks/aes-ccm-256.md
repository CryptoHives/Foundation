| Description                          | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1.286 μs | 0.0090 μs | 0.0085 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     2.022 μs | 0.0134 μs | 0.0126 μs |    3288 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1.248 μs | 0.0088 μs | 0.0082 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     2.001 μs | 0.0146 μs | 0.0136 μs |    3328 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8.311 μs | 0.0819 μs | 0.0766 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.328 μs | 0.0739 μs | 0.0692 μs |    5080 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8.247 μs | 0.0914 μs | 0.0855 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.257 μs | 0.0886 μs | 0.0829 μs |    5120 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    63.703 μs | 0.3597 μs | 0.3188 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    76.292 μs | 0.5981 μs | 0.5595 μs |   19416 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    64.029 μs | 0.5208 μs | 0.4872 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    75.727 μs | 0.4781 μs | 0.4238 μs |   19456 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,051.762 μs | 8.7001 μs | 8.1381 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,252.980 μs | 7.1854 μs | 6.0002 μs |  265204 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,018.635 μs | 6.0097 μs | 4.6920 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,256.303 μs | 6.8147 μs | 6.0411 μs |  265244 B |