| Description                          | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1.280 μs |  0.0065 μs |  0.0061 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     2.032 μs |  0.0170 μs |  0.0142 μs |    2808 B |
|                                      |              |              |            |            |           |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1.242 μs |  0.0102 μs |  0.0095 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1.929 μs |  0.0208 μs |  0.0194 μs |    2848 B |
|                                      |              |              |            |            |           |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8.193 μs |  0.0413 μs |  0.0366 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.124 μs |  0.0610 μs |  0.0570 μs |    2808 B |
|                                      |              |              |            |            |           |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8.174 μs |  0.0935 μs |  0.0875 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.134 μs |  0.0584 μs |  0.0546 μs |    2848 B |
|                                      |              |              |            |            |           |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    63.270 μs |  0.3350 μs |  0.2797 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74.947 μs |  0.4991 μs |  0.4424 μs |    2808 B |
|                                      |              |              |            |            |           |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    63.595 μs |  0.4426 μs |  0.3924 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    74.968 μs |  0.6204 μs |  0.5803 μs |    2848 B |
|                                      |              |              |            |            |           |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,013.367 μs | 10.2607 μs |  9.5979 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,190.685 μs | 10.7234 μs | 10.0307 μs |    2808 B |
|                                      |              |              |            |            |           |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,011.768 μs |  6.1974 μs |  5.4939 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,194.736 μs |  6.8932 μs |  5.7561 μs |    2848 B |