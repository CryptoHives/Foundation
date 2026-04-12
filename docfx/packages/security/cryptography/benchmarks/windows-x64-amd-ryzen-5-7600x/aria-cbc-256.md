| Description                           | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     3.193 μs |  0.0240 μs |  0.0201 μs |    1496 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128B         |     3.256 μs |  0.0191 μs |  0.0160 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     3.043 μs |  0.0125 μs |  0.0104 μs |    1496 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128B         |     3.263 μs |  0.0253 μs |  0.0224 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    19.959 μs |  0.0992 μs |  0.0928 μs |    3736 B |
| Decrypt · ARIA-256-CBC (Managed)      | 1KB          |    23.403 μs |  0.1327 μs |  0.1242 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    19.956 μs |  0.1064 μs |  0.0995 μs |    3736 B |
| Encrypt · ARIA-256-CBC (Managed)      | 1KB          |    23.419 μs |  0.1149 μs |  0.1019 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   154.282 μs |  0.9999 μs |  0.9353 μs |   21656 B |
| Decrypt · ARIA-256-CBC (Managed)      | 8KB          |   184.216 μs |  0.8865 μs |  0.8292 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   156.230 μs |  0.8389 μs |  0.7436 μs |   21656 B |
| Encrypt · ARIA-256-CBC (Managed)      | 8KB          |   185.118 μs |  1.2479 μs |  1.1063 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,451.999 μs | 14.9909 μs | 14.0225 μs |  328856 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128KB        | 2,942.914 μs |  9.5008 μs |  8.4222 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,476.034 μs | 10.4285 μs |  9.2446 μs |  328856 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128KB        | 2,956.943 μs |  9.4065 μs |  8.7988 μs |         - |