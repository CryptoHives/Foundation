| Description                                              | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| ComputeHash | Streebog-256 | Streebog-256 (Managed)      | 128B         |     2.347 μs |  0.0099 μs |  0.0093 μs |     112 B |
| ComputeHash | Streebog-256 | Streebog-256 (OpenGost)     | 128B         |     3.553 μs |  0.0684 μs |  0.0640 μs |     464 B |
| ComputeHash | Streebog-256 | Streebog-256 (BouncyCastle) | 128B         |     4.388 μs |  0.0322 μs |  0.0302 μs |     200 B |
|                                                          |              |              |            |            |           |
| ComputeHash | Streebog-256 | Streebog-256 (Managed)      | 137B         |     2.312 μs |  0.0193 μs |  0.0161 μs |     112 B |
| ComputeHash | Streebog-256 | Streebog-256 (OpenGost)     | 137B         |     3.580 μs |  0.0430 μs |  0.0382 μs |     464 B |
| ComputeHash | Streebog-256 | Streebog-256 (BouncyCastle) | 137B         |     4.416 μs |  0.0880 μs |  0.1144 μs |     200 B |
|                                                          |              |              |            |            |           |
| ComputeHash | Streebog-256 | Streebog-256 (Managed)      | 1KB          |     8.673 μs |  0.0303 μs |  0.0236 μs |     112 B |
| ComputeHash | Streebog-256 | Streebog-256 (OpenGost)     | 1KB          |    12.775 μs |  0.1071 μs |  0.1002 μs |     464 B |
| ComputeHash | Streebog-256 | Streebog-256 (BouncyCastle) | 1KB          |    16.320 μs |  0.1018 μs |  0.0795 μs |     200 B |
|                                                          |              |              |            |            |           |
| ComputeHash | Streebog-256 | Streebog-256 (Managed)      | 1025B        |     8.882 μs |  0.1531 μs |  0.1358 μs |     112 B |
| ComputeHash | Streebog-256 | Streebog-256 (OpenGost)     | 1025B        |    12.924 μs |  0.2059 μs |  0.1719 μs |     464 B |
| ComputeHash | Streebog-256 | Streebog-256 (BouncyCastle) | 1025B        |    16.555 μs |  0.3195 μs |  0.2989 μs |     200 B |
|                                                          |              |              |            |            |           |
| ComputeHash | Streebog-256 | Streebog-256 (Managed)      | 8KB          |    77.115 μs |  0.7905 μs |  0.7394 μs |     112 B |
| ComputeHash | Streebog-256 | Streebog-256 (OpenGost)     | 8KB          |    87.462 μs |  0.8149 μs |  0.7623 μs |     464 B |
| ComputeHash | Streebog-256 | Streebog-256 (BouncyCastle) | 8KB          |   112.291 μs |  0.6895 μs |  0.5758 μs |     200 B |
|                                                          |              |              |            |            |           |
| ComputeHash | Streebog-256 | Streebog-256 (Managed)      | 128KB        |   938.376 μs |  3.2018 μs |  2.4998 μs |     112 B |
| ComputeHash | Streebog-256 | Streebog-256 (OpenGost)     | 128KB        | 1,416.082 μs | 28.2036 μs | 35.6685 μs |     464 B |
| ComputeHash | Streebog-256 | Streebog-256 (BouncyCastle) | 128KB        | 1,768.120 μs | 14.3532 μs | 12.7237 μs |     200 B |