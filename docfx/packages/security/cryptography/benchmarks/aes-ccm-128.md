| Description                          | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| Decrypt · AES-128-CCM (Managed)      | 128B         |   1.026 μs | 0.0068 μs | 0.0063 μs |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1.586 μs | 0.0111 μs | 0.0104 μs |    2424 B |
|                                      |              |            |           |           |           |
| Encrypt · AES-128-CCM (Managed)      | 128B         |   1.002 μs | 0.0058 μs | 0.0048 μs |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1.572 μs | 0.0091 μs | 0.0085 μs |    2464 B |
|                                      |              |            |           |           |           |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6.430 μs | 0.0227 μs | 0.0201 μs |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   7.990 μs | 0.0506 μs | 0.0423 μs |    2424 B |
|                                      |              |            |           |           |           |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6.442 μs | 0.0349 μs | 0.0310 μs |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8.131 μs | 0.1546 μs | 0.1519 μs |    2464 B |
|                                      |              |            |           |           |           |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  49.763 μs | 0.2478 μs | 0.2197 μs |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  58.815 μs | 0.2744 μs | 0.2566 μs |    2424 B |
|                                      |              |            |           |           |           |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  49.843 μs | 0.3665 μs | 0.3249 μs |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59.207 μs | 0.2159 μs | 0.1914 μs |    2464 B |
|                                      |              |            |           |           |           |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 795.284 μs | 4.0165 μs | 3.7570 μs |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 931.020 μs | 4.5087 μs | 4.2175 μs |    2424 B |
|                                      |              |            |           |           |           |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 795.945 μs | 5.3548 μs | 5.0089 μs |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 933.324 μs | 3.4440 μs | 3.2215 μs |    2464 B |