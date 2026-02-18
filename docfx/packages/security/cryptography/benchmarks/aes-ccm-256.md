| Description                          | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1.275 μs | 0.0075 μs | 0.0071 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     1.963 μs | 0.0122 μs | 0.0108 μs |    2808 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1.243 μs | 0.0073 μs | 0.0068 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1.915 μs | 0.0115 μs | 0.0102 μs |    2848 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8.157 μs | 0.0329 μs | 0.0292 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.057 μs | 0.0671 μs | 0.0595 μs |    2808 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8.114 μs | 0.0369 μs | 0.0327 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.047 μs | 0.0638 μs | 0.0566 μs |    2848 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    63.245 μs | 0.2685 μs | 0.2512 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74.529 μs | 0.2984 μs | 0.2645 μs |    2808 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    63.204 μs | 0.2234 μs | 0.1980 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74.538 μs | 0.5748 μs | 0.5377 μs |    2848 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,007.703 μs | 4.6727 μs | 4.3709 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,181.143 μs | 6.6818 μs | 5.9233 μs |    2808 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,009.274 μs | 5.1040 μs | 4.5245 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,179.448 μs | 8.6680 μs | 8.1081 μs |    2848 B |